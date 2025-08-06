from PyQt5 import QtWidgets
from PyQt5.QtWidgets import QApplication, QDialog, QVBoxLayout, QLabel, QPushButton, QTextEdit, QHBoxLayout
from PyQt5.QtGui import QIcon
from PyQt5.QtCore import Qt
import sys
from PyQt5.uic import loadUi
import sqldb as sql
from datetime import datetime, timedelta

class LoginWindow(QDialog):
    def __init__(self):
        super(LoginWindow, self).__init__()
        loadUi("loginform.ui",self)
        self.loginBtn.clicked.connect(self.pressed)

    def pressed(self):
        correct, user_id = sql.checkUser(self.usernameEdit.toPlainText(), self.passwordEdit.toPlainText())
        if(correct):
            self.hide()
            mainWindow = MainWindow()
            mainWindow.exec_()
        else:
            print(user_id)



class MainWindow(QDialog):
    def __init__(self):
        super().__init__()

        layout = QVBoxLayout(self)

        data = sql.getAllRequests()

        for item in data:
            box_layout = QHBoxLayout()
            
            header_label = QLabel(str(item[7]))
            description_label = QLabel(str(item[2]))
            
            header_label.setStyleSheet("font-size: 18px; font-weight: bold; color: #333;")
            description_label.setStyleSheet("font-size: 14px; color: #666;")

            button = QPushButton('Выбрать')
            button.setIcon(QIcon('images/' + str(item[6])))
            button.setStyleSheet("background-color: #4CAF50; color: white; border: none; padding: 8px 16px; text-align: center; text-decoration: none; display: inline-block; font-size: 14px; margin: 4px 2px; cursor: pointer; border-radius: 8px;")
            button.clicked.connect(lambda checked, message=str(item[7]): self.show_message(message))

            box_layout.addWidget(header_label)
            box_layout.addWidget(description_label)
            box_layout.addWidget(button)

            layout.addLayout(box_layout)
            layout.addSpacing(10)

        layout.setAlignment(Qt.AlignTop)
        self.setLayout(layout)

    def show_message(self, message):
        # QMessageBox.information(self, 'Label Clicked', f'You clicked on {message}')

        self.hide()
        editform = EditWindow(message)
        editform.exec_()



class EditWindow(QDialog):
    def __init__(self, message):
        super().__init__()
        loadUi("editform.ui", self)
        self.loaddata(message)
        self.pushButton.clicked.connect(self.pressedBack)

    def loaddata(self, message):
        result = sql.getRequest(message)
        start_date = result[2]
        end_date = result[3]

        price = result[4]
        rule = result[5]

        rule = sql.getRuleName(rule)

        y, m, d = map(int, start_date.split("/"))
        start_date = datetime(y, m, d)
        y, m, d = map(int, end_date.split("/"))
        end_date = datetime(y, m, d)

        amount_days = 0
        current_date = start_date
        while current_date <= end_date:
            current_date += timedelta(days=1)
            amount_days+=1

        self.tableWidget.setRowCount(amount_days)

        current_date = start_date

        row = 0
        while current_date <= end_date:
            current_date += timedelta(days=1)
            self.tableWidget.setItem(row, 0, QtWidgets.QTableWidgetItem(current_date.strftime('%Y/%m/%d')))
            self.tableWidget.setItem(row, 1, QtWidgets.QTableWidgetItem(str(price) + "$"))
            self.tableWidget.setItem(row, 2, QtWidgets.QTableWidgetItem(rule))
            
            row+=1

    def pressedBack(self):
        self.hide()
        mainForm = MainWindow()
        mainForm.exec_()

app = QApplication(sys.argv)
mainWindow = LoginWindow()

widget = QtWidgets.QStackedWidget()
widget.addWidget(mainWindow)
widget.setFixedHeight(450)
widget.setFixedWidth(580)
widget.show()

try:
    sys.exit(app.exec_())
except:
    print("Exiting")