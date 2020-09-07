"use strict";

$(document).ready(() => {
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/chathub")
        .withAutomaticReconnect()
        .build();

    //Disable send button until connection is established
    document.getElementById("sendButton").disabled = true;

    connection.on("ReceiveMessage", function (user, message) {

        var msg = message.msg.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

        const msgsList = document.getElementById('messagesList');
        let li = document.createElement('li');
        var encodedMsg = /*user.userName + ": " +*/ msg;
        li.textContent = encodedMsg;
        msgsList.append(li);
        $('#messagesList"').append(`<li>${encodedMsg}</li>`);
    });

    connection.start().then(function () {
        document.getElementById("sendButton").disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });

    document.getElementById("sendButton").addEventListener("click", function (event) {
        //var user = document.getElementById("userInput").value;
        var message = document.getElementById("messageInput").value;
        connection.invoke("SendMessage", /*{ Username: user },*/ { msg: message}).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
});