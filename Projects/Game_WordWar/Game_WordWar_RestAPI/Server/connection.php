<?php
    function GetConnection(){
    $connection = new PDO('mysql:host=localhost;dbname=mydb;','root','');
    $connection->exec("SET NAMES 'utf8'");
    return $connection;
}
?>
