namespace('Listy.Home.Index');

Listy.Home.Index.Item = function (dto) {
    var self = this;

    self.name = ko.observable(dto.Name);
    self.editing = ko.observable(false);
    self.oldName = '';

    self.toSaveModel = function() {
        return {
            Id: dto.Id,
            Name: self.name()
        };
    };

    self.startEditing = function () {
        self.editing(true);
        self.oldName = self.name();
    };

    self.cancel = function () {
        self.editing(false);
        self.name(self.oldName);
    };

    self.save = function () {
        $.post('/api/listitem/' + dto.Id, self.toSaveModel())
            .error(Listy.handleAjaxFail)
            .success(function() {
            })
            .always(function() {
                self.editing(false);
            });
    };
};


