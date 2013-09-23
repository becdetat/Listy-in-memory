namespace('Listy.Home.Index');

Listy.Home.Index.Item = function (dto) {
    var self = this;

    self.id = dto ? dto.Id : [];
    self.name = ko.observable(dto ? dto.Name : '');
    self.editing = ko.observable(false);
    self.oldName = [];

    self.toSaveModel = function() {
        return {
            Id: self.id,
            Name: self.name()
        };
    };

    self.startEditing = function () {
        self.editing(true);
        self.oldName = self.name();
    };

    self.finishEditing = function() {
        self.editing(false);
    };

    self.cancelEditing = function () {
        self.editing(false);
        self.name(self.oldName);
    };
};


