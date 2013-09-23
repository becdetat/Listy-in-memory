var namespace = function (declr) {
    var current = null;
    var cmd = 'var ';
    $.each(declr.split('.'), function (i) {
        current = current ? current + '.' : '';
        current += this;
        cmd += current + ' = ' + current + ' || {};\n';
    });
    $('body').append('<script type="text/javascript">' + cmd + '<' + '/script>');
};
