namespace('Listy.Home.Index');

Listy.Home.Index.ViewModel = function() {
    var self = this;

    self.lists = ko.observableArray();

    self.createNewList = function () {
        alert('not implemented yet');
    };

    $.get('/api/lists')
        .error(Listy.handleAjaxFail)
        .success(function (dtos) {
            self.lists(dtos.map(function (dto) {
                return new Listy.Home.Index.List(dto);
            }));
        });
};

