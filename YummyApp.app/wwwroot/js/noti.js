// Add this JavaScript code to your view or a separate JS file

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/notificationHub") // Replace with the URL of your SignalR Hub
    .build();

connection.start().then(function () {
    console.log("Connected to the NotificationHub.");
}).catch(function (err) {
    console.error(err.toString());
});

connection.on("ReceiveNotification", function (message) {
    // Handle the received notification
    console.log("Received notification: " + message);

    // Update the badge count
    const notificationBadge = document.getElementById("notification-badge");
    let count = parseInt(notificationBadge.innerText);
    count++;
    notificationBadge.innerText = count;
});
