var usersListModel;
$(document).ready(() => {
    usersListModel = new UsersListModel();
    ko.applyBindings(usersListModel);

    usersListModel.getAllUsers();
});

var helper = {
    sendAjaxRequest: (httpMethod, callback, url, data) => {
        $.ajax("/api/user" + (url ? "/" + url : ""),
       {
           type: httpMethod,
           success: callback,
           data: data
       });
    }
};

function UsersListModel() {
    var model = this;
    this.usersList = ko.observableArray();
    this.newUser = ko.observable(new NewUserModel());

    this.createUser = function(formElement) {
        var newUser = {
            FirstName: $('#firstName').val(),
            LastName: $('#lastName').val(),
            FullName: '',
            Id: 0
        };
        helper.sendAjaxRequest("POST", (response) => {
            this.getAllUsers();
        }, 
        null, newUser);
    };

    this.getAllUsers = function () {
        helper.sendAjaxRequest("GET", (allUsers) => {
            if (allUsers) {
                this.usersList.removeAll();
                for (var i = 0; i < allUsers.length; i++) {

                    this.usersList.push(new NewUserModel(allUsers[i].Id, allUsers[i].FirstName, allUsers[i].LastName));
                }
            }
        });
    }

}

function NewUserModel(id, firstName, lastName) {
    this.FirstName = ko.observable(firstName);
    this.LastName = ko.observable(lastName);
    this.FullName = ko.computed(() => { return this.FirstName() + ' ' + this.LastName(); }, this);
    this.Id = ko.observable(id);
}