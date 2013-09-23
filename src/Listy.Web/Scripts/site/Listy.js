namespace('Listy');

Listy.handleAjaxFail = function (jqXHR, exception) {
    if (jqXHR.status === 0) return;

    console.log('AJAX failed: ' + jqXHR.status + ', ' + exception);

    toastr.error(Listy.formatErrorMessage(jqXHR, exception));
};

Listy.formatErrorMessage = function (jqXHR, exception) {
    if (exception === 'timeout') {
        return ('The server took too long to respond, please try again');
    } else if (exception === 'abort') {
        return ('The request was cancelled, please try again');
    } else {
        return ('Ooops! Something went wrong, please refresh and try again');
    }
};