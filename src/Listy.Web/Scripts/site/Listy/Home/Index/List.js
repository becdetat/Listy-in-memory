namespace('Listy.Home.Index');

Listy.Home.Index.List = function(dto) {
    var self = this;

    self.name = ko.observable(dto.Name);
    self.items = ko.observableArray(dto.Items.map(function(x) {
        return new Listy.Home.Index.Item(x);
    }));
    self.editing = ko.observable(false);
    self.oldName = '';
    self.isAddingItem = ko.observable(false);
    self.editedItem = ko.observable();

    self.startEditing = function() {
        self.editing(true);
        self.oldName = self.name();
    };
    self.cancel = function() {
        self.editing(false);
        self.name(self.oldName);
    };

    self.startEditingItem = function(item) {
        item.startEditing();
        self.editedItem(item);
    };

    self.cancelEditingItem = function(item) {
        item.cancelEditing();
        if (self.isAddingItem()) {
            self.items.pop();
            self.isAddingItem(false);
        }
    };

    self.save = function() {
        $.post('/api/list/' + dto.Id, self.toSaveViewModel())
            .error(Listy.handleAjaxFail)
            .success(function() {
            })
            .always(function() {
                self.editing(false);
                if (self.editedItem()) {
                    self.editedItem().finishEditing();
                    self.editedItem(null);
                }
                self.isAddingItem(false);
            });
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

    self.addItem = function () {
        self.isAddingItem(true);
        var item = new Listy.Home.Index.Item();
        item.startEditing();
        self.editedItem(item);
        self.items.push(item);
    };
};
