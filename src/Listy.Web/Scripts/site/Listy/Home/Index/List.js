namespace('Listy.Home.Index');

Listy.Home.Index.List = function(dto) {
    var self = this;

    self.name = ko.observable(dto.Name);
    self.items = ko.observableArray(dto.Items.map(function(x) {
        return new Listy.Home.Index.Item(x);
    }));
    self.editing = ko.observable(false);
    self.oldName = '';

    self.startEditing = function() {
        self.editing(true);
        self.oldName = self.name();
    };
    self.cancel = function() {
        self.editing(false);
        self.name(self.oldName);
    };
    self.save = function() {
        $.post('/api/list/' + dto.Id, self.toSaveViewModel())
            .error(Listy.handleAjaxFail)
            .success(function() {
            })
            .always(function() {
                self.editing(false);
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
        // Whoops, implement editing an item first.
        
        //var item = new Listy.Home.Index.Item();
        //item.
        //self.items().add();
    };
};
