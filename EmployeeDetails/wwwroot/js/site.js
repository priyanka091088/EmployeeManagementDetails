const connection = new signalR.HubConnectionBuilder()
    .withUrl("/NotificationHub")
    .build();
connection.on("sendToUser", (employeeName, employeeSurname) => {
   
    var notify = employeeName + " " + employeeSurname + " Was Added"
    var li = document.createElement("li");
    li.textContent = notify;
    var notifyMenu = document.getElementById("counter");
    notifyMenu.appendChild(li);
});

connection.on("RecieveEditProfileMessage", (name,surname) => {
   
    var notify = name +" " + surname + " edited their profile."
    var li = document.createElement("li");
    li.textContent = notify;
    var notifyMenu = document.getElementById("counter");
    notifyMenu.appendChild(li);
});

connection.on("RecieveAddDepartMessage", (name) => {
    var notify = "New Department Of " + name + " Was Added By Admin"
    var li = document.createElement("li");
    li.textContent = notify;
    var notifyMenu = document.getElementById("NotificationMenu");
    notifyMenu.appendChild(li);
  
});

try {
    connection.start();
    console.log("connected");
} catch (err) {
    console.log(err);
}

if (document.getElementById("AddEmployee")) {
    document.getElementById("AddEmployee").addEventListener("click", function (event) {
        var Name = document.getElementById("nameInput").value;
        var Surname = document.getElementById("surnameInput").value;
       
        connection.invoke("SendMessage", Name, Surname).catch(function (err) {
            return console.error(err.toString());
        });
    });
}

if (document.getElementById("editProfileButton")) {
    document.getElementById("editProfileButton").addEventListener("click", function (event) {
        var name = document.getElementById("nameInput").value;
        var surname = document.getElementById("SurnameInput").value;
        connection.invoke("EditProfileMessage", name,surname).catch(function (err) {
            return console.error(err.toString());
        });
    });
}

if (document.getElementById("AddDepartmentButton")) {
    document.getElementById("AddDepartmentButton").addEventListener("click", function (event) {
        var name = document.getElementById("DepartNameInput").value;
        connection.invoke("AddDepartmentMessage", name).catch(function (err) {
            return console.error(err.toString());
        });
    });
}


connection.onclose(async () => {
    await start();
});