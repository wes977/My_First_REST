﻿$('#saveContact').click(function () {
    $.post("api/contact",
          $("#saveContactForm").serialize(),
          function (value) {
              $('#contacts').append('<li>' + value.Name + '</li>');
          },
          "json"
    );
});