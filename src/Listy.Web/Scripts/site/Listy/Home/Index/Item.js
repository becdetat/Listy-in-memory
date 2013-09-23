namespace('Listy.Home.Index');

Listy.Home.Index.Item = function (dto) {
    var self = this;

    self.name = ko.observable(dto.Name);

    self.toSaveModel = function() {
        return {
            Id: dto.Id,
            Name: self.name()
        };
    };
};


