(function ($) {
  jQuery(document).ready(function ($) {
    scroll();
    hamburger();
    navAlt();
    navHide();
    contactForm();
    $(window).scroll(function() {
      navAlt();
      navHide();
    });
  });
})(jQuery);

var scroll = function() {
  $(".scroll").click(function (event) { // When a link with the .scroll class is clicked
    event.preventDefault(); // Prevent the default action from occurring
    $('html,body').animate({
      scrollTop: $(this.hash).offset().top
    }, 500); // Animate the scroll to this link's href value
  });
}

var hamburger = function() {
  $('.hamburger-menu').on('click', function() {
    $('.bar').toggleClass('animate');
    $('nav ul.navbar').slideToggle('slow');
  });
}

var navAlt = function() {
  var x = $(window).scrollTop();
  var y = $(window).height();
  if ((x > $('section#about').offset().top - 150 && x < $('section#gallery').offset().top - 150) || (x > $('section#download').offset().top - 150 && x < $('section#contact').offset().top - 150)) {
    $('nav').addClass('alt');
  } else {
    $('nav').removeClass('alt');
  }
}

var navHide = function() {
  var x = $(window).scrollTop(),
      y = $(window).height();
      s1 = $('section#about').offset().top;
      s2 = $('section#gallery').offset().top;
      s3 = $('section#download').offset().top;
      s4 = $('section#contact').offset().top;
  if ((x>100 && !(x>s1-125)) || (x>s1+100 && !(x>s2-125)) || (x>s2+100 && !(x>s3-125)) || (x>s3+100  && !(x>s4-125))) {
    $('nav').addClass('hide');
  } else if (x > s4 + 100) {
    $('nav').addClass('hide');
  } else {
    $('nav').removeClass('hide');
  }
}

var contactForm = function () {
  $("#contact-submit").on('click', function () {
    $contact_form = $('#contact-form');
    var fields = $contact_form.serialize();
    $.ajax({
      type: "POST",
      url: "js/contact.php",
      data: fields,
      dataType: 'json',
      success: function (response) {
        if (response.status) {
          $('#contact-form input').val('');
          $('#contact-form textarea').val('');
        }
        $('#response').empty().html(response.html);
      }
    });
    return false;
  });
}
