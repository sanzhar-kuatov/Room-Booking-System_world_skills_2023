<!DOCTYPE html>
<html>
<head>
<title>Sessia 3</title>
<meta charset="utf-8">
<link rel="stylesheet" href="./style.css">
</head>
<body>
    <Header>
        <div class="logo">
            <img src="./image/logo.png" alt="" class="img_logo">
        </div>
        <div class="poisk">
            <form action="index.php" method="POST">
            <input type="text" name="poisk" class="poisk_str" placeholder="Seocho-gu">
            <input type="submit" value="Search" class="button">
            </form>
        </div>
        <div class="welcome">
        <?php 
            $link = mysqli_connect("localhost", "root", "", "project");
            $sql = "SELECT name FROM users where ID=3;";
            if($result = mysqli_query($link, $sql))
                {             
                    $row = mysqli_fetch_assoc($result);
                    $name = $row["name"];
                    echo "<h3> Welcome ".$name."</h3>";
                    $result->free();
                }
                else{
                echo "Ошибка: " . $linc->error;
                }
            $link->close();
        ?>
        </div>
    </Header>
    <main>
<?php 
    $link = mysqli_connect("localhost", "root", "", "project");

    $sql = "SELECT items.ID as ID, items.UserID as UserID, areas.Name as AreaID, items.Title as Title,
            items.Capacity as Capacity, items.Description as Descrip, pict.PathPict as PathPict 
            FROM items 
            INNER JOIN areas ON items.AreaID = areas.ID 
            LEFT JOIN pict ON pict.ItemID = items.ID";
    
    if($result = mysqli_query($link, $sql)) {
        foreach($result as $row) {
            echo "<div class='block'>";
            if (!empty($row["PathPict"])) {
                echo '<img src="./image/'.$row["PathPict"].'" alt="" class="img_block">'; // Outputting the image if it exists
            } else {
                echo '<img src="default_image.png" alt="" class="img_block">'; // Provide a default image if PathPict is empty
            }
            $Itemid = $row["ID"];
            $UserId = $row["UserID"];
            $AreaId = $row["AreaID"];
            $Title = $row["Title"];
            $Capacity = $row["Capacity"];
            $Descrip = $row["Descrip"];
            echo '<h4> Property title: '.$Title.'</h4> <br>';
            echo '<span> Area: '.$AreaId.'</span> ';
            echo '<span> '.$Capacity.' people</span> <br>';
            echo "</div>";
        }
        $result->free();
    } else {
        echo "Ошибка: " . $link->error;
    }
    $link->close();
    
?>
    </main>
</body>
</html>


