namespace('Listy.Home.Index');

Listy.Home.Index.ViewModel = function() {
    var self = this;

    self.lists = ko.observableArray();
    self.currentList = ko.observable();
    self.currentListItem = ko.observable();
    self.currentListItemModal = $('#currentListItemModal');

    self.createNewList = function () {
        alert('not implemented yet');
    };
    
    self.startEditingListItem = function (item) {
        item.startEditing();
        self.currentListItem(item);
        self.currentListItemModal.modal();
    };

    self.cancelEditingListItem = function () {
        self.currentListItem().cancelEditing();
        self.currentListItem(false);
        self.currentList(false);
        self.currentListItemModal.modal('hide');
    };

    self.saveEditedListItem = function () {
        if (self.currentListItem().isNew()) {
            self.currentList().items.push(self.currentListItem());
            self.currentList().save();
        } else {
            self.currentListItem().save();
        }
        
        self.currentListItem(false);
        self.currentList(false);
        self.currentListItemModal.modal('hide');
    };

    self.startAddingListItem = function (list) {
        var item = new Listy.Home.Index.Item();
        item.isNew(true);
        self.currentList(list);
        self.startEditingListItem(item);
        self.currentListItemModal.modal();
    };

    $.get('/api/lists')
        .error(Listy.handleAjaxFail)
        .success(function (dtos) {
            self.lists(dtos.map(function (dto) {
                return new Listy.Home.Index.List(dto);
            }));
        });
};

