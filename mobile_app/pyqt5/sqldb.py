import mysql.connector

def getDataBase():
    mydb = mysql.connector.connect(
        host = "localhost",
        user = "root",
        password = "",
        database = "project"
    )
    return mydb

def checkUser(username, password):
    query = "SELECT id FROM users WHERE name = %s AND password = %s"
    mydb = getDataBase()
    mycursor = mydb.cursor()
    mycursor.execute(query, (username, password))
    result = mycursor.fetchone()
    if result is None:
        return False, "Wrong password or username"
    return  True, result[0]
                         
def getAllRequests():
    query = "SELECT itemprices.*, items.title FROM itemprices INNER JOIN items ON itemprices.itemid = items.id"
    mydb = getDataBase()
    mycursor = mydb.cursor()
    mycursor.execute(query)
    result = mycursor.fetchall()
    # print(result)
    return result

def getRequestID(name):
    query = "SELECT id FROM items WHERE title = %s"
    mydb = getDataBase()
    mycursor = mydb.cursor()
    mycursor.execute(query, (name,))
    id = mycursor.fetchone()[0]
    print("id", id)
    return id

def getRequest(name):
    id = getRequestID(name)
    query = "SELECT * FROM itemprices WHERE itemid = %s"
    mydb = getDataBase()
    mycursor = mydb.cursor()
    mycursor.execute(query, (id,))
    result = mycursor.fetchone()
    print("request:", result)
    return result

def getRuleName(id):
    query = "SELECT name FROM rules WHERE id = %s"
    mydb = getDataBase()
    mycursor = mydb.cursor()
    mycursor.execute(query, (id,))
    name = mycursor.fetchone()[0]
    return name