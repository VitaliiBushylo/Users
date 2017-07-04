$(document).ready(() => {
    var usersListModel = new UsersListModel();
    ko.applyBindings(usersListModel);
    usersListModel.getAllUsers();
});

function UsersListModel() {
    this.usersList = ko.observableArray();
    this.newUser = ko.observable(new NewUserModel());

    this.getAllUsers = function() {
        $.getJSON('api/user', null, (allUsers) => {
            if (allUsers) {
                this.usersList.removeAll();
                for (var i = 0; i < allUsers.length; i++) {
                    this.usersList.push(allUsers[i]);
                }
            }
        });
    };
}

function NewUserModel() {
    this.FirstName = ko.observable();
    this.LastName = ko.observable();
    this.FullName = ko.computed(() =>{ return this.FirstName + ' ' + this.LastName });
    this.Id = ko.observable();
}