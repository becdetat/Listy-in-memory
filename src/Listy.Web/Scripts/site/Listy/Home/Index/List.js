namespace('Listy.Home.Index');

Listy.Home.Index.List = function(dto) {
    var self = this;

    self.name = ko.observable(dto.Name);
    self.items = ko.observableArray(dto.Items.map(function(x) {
        return new Listy.Home.Index.Item(x);
    }));
    self.isEditingName = ko.observable(false);
    self.oldName = '';

    self.startEditingName = function() {
        self.isEditingName(true);
        self.oldName = self.name();
    };
    self.cancelEditingName = function () {
        self.isEditingName(false);
        self.name(self.oldName);
    };
    self.handleKeyUp = function(data, event) {
        if (event.keyCode === 27) {
            self.cancelEditingName();
            return false;
        }
    };

    self.save = function () {
        $.post('/api/list/' + dto.Id, self.toSaveViewModel())
            .error(Listy.handleAjaxFail)
            .success(function() {
            })
            .always(function() {
            });
        self.isEditingName(false);
        return false;
    };
    self.toSaveViewModel = function() {
        return {
            Name: self.name(),
            Items: self.items().map(function(x) {
                return x.toSaveModel();
            })
        };
    };
};
