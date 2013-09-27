namespace('Listy.Home.Index');

Listy.Home.Index.Item = function (dto) {
    var self = this;

    self.isNew = ko.observable(dto ? false : true);
    
    self.id = dto ? dto.Id : [];
    self.name = ko.observable(dto ? dto.Name : '');
    self.oldName = '';

    self.toSaveModel = function() {
        return {
            Id: self.id,
            Name: self.name()
        };
    };

    self.startEditing = function() {
        self.oldName = self.name();
    };
    self.cancelEditing = function() {
        self.name(self.oldName);
    };

    self.save = function () {
        self.isNew(false);
        $.post('/api/listitem/' + self.id, self.toSaveModel())
            .error(Listy.handleAjaxFail)
        ;
        return false;
    };
};


