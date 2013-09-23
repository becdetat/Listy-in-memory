namespace('Listy.Home.Index');

Listy.Home.Index.ViewModel = function() {
    var self = this;

    self.lists = ko.observableArray();

    $.get('/api/lists')
        .error(Listy.handleAjaxFail)
        .success(function (dtos) {
            self.lists(dtos.map(function (dto) {
                return new Listy.Home.Index.List(dto);
            }));
        });
};

Listy.Home.Index.List = function(dto) {
    var self = this;

    self.name = ko.observable(dto.Name);
};
