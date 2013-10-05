namespace('Listy.Searchy.Index');

Listy.Searchy.Index.ViewModel = function () {
    var self = this;

    self.term = ko.observable();
    self.items = ko.observableArray();

    self.term.subscribe(function (term) {
        $.get('/api/search/?term=' + term)
            .error(Listy.handleAjaxFail)
            .success(function (dtos) {
                self.items(dtos.map(function (dto) {
                    return new Listy.Searchy.Index.Item(dto);
                }));
            });
    });
};

Listy.Searchy.Index.Item = function (dto) {
    var self = this;
    
    self.list = dto.List;
    self.item = dto.Item;
};