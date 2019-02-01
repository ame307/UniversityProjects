<?php
include("./connection.php");
$connection = GetConnection();
$request_method=$_SERVER["REQUEST_METHOD"];

switch($request_method) {
    case 'GET':
        if(!empty($_GET["name"])) {
         $name=$_GET["name"];
         GetUserByName($name);
        }
        else {
          GetTopHighScores();
        } break;
    case 'POST':
        RegistrateUser();
        break;
    case 'PUT':
        UpdateHighScore();
        break;
    case 'DELETE':
        DeleteUser();
        break;
    default:
        header("HTTP/1.1 405 Method Not Allowed");
        break;
}

function GetTopHighScores()
{
    global $connection;
    $queryString = "SELECT * FROM scoreboard ORDER BY score DESC";
    $statement = $connection->prepare($queryString);
    $success = $statement->execute();
    if($success){
        $result = $statement->fetchAll();
        header('Content-Type: application/json');
        echo json_encode($result);
    }
}

function GetUserByName($name) {
    global $connection;
    $queryString = "SELECT * FROM scoreboard WHERE username = '".$name."'";
    $statement = $connection->prepare($queryString);
    $success = $statement->execute();
    $result = $statement->fetchAll();
    if($success){
        header('Content-Type: application/json');
        echo json_encode($result);
    }
}

function RegistrateUser()  {
    global $connection;
    $data = json_decode(file_get_contents('php://input'), true);
    $name=$data["Username"];
    $password=$data["Password"];
    $queryString = "INSERT INTO scoreboard(username, password) VALUES('".$name."', '".$password."')";
    $statement = $connection->prepare($queryString);
    $success = $statement->execute();
    if($success){
        $result=array('status' => 1, 'status_message' =>'Registration Succesful.');
    }
    else {
        $result=array('status' => 0, 'status_message' =>'Registration Failed.');
    }
    header('Content-Type: application/json');
    echo json_encode($result);
 }

function UpdateHighScore() {
    global $connection;
    $data = json_decode(file_get_contents('php://input'), true);
    $name=$data["Username"];
    $highscore=$data["Score"];
    $queryString = "UPDATE scoreboard SET score=".$highscore." WHERE username='".$name."'";
    $statement = $connection->prepare($queryString);
    $success = $statement->execute();
    if($success){
        $result=array('status' => 1, 'status_message' =>'Update Succesful.');
    }
    else {
        $result=array('status' => 0, 'status_message' =>'Update Failed.');
    }
    header('Content-Type: application/json');
    echo json_encode($result);
}

function DeleteUser() {
    global $connection;
    $data = json_decode(file_get_contents('php://input'), true);
    $name=$data["Username"];
    $queryString = "DELETE FROM scoreboard WHERE username='".$name."'";
    $statement = $connection->prepare($queryString);
    $success = $statement->execute();
    if($success){
        $result=array('status' => 1, 'status_message' =>'Account deleted.');
    }
    else {
        $result=array('status' => 0, 'status_message' =>'Delete Failed.');
    }
    header('Content-Type: application/json');
    echo json_encode($result);
}
