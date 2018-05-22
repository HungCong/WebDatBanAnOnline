var order = {
    init: function () {
        order.regEvents();
    },
    regEvents: function () {
        $('.btn-Order').off('click').on('click', function () {
            var list = [];
            list.push({
                BookDate: $('#date-now').val(),
                Quantity: $('.quantity').val(),
                Time: $('.AtTime').val()
            });
           

            $.ajax({
                url: 'Home/BookCustomer',
                data: {Cus_book: JSON.stringify(list)},
                dataType: 'Json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/dat-ban";
                    }
                }
            });
        });
    }
}

order.init();