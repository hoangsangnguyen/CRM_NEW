/* JS menu list category click call
========================================*/
$(document).ready(function () {
    jQuery("#menu-icon").on("click", function () {
        jQuery(".sf-menu-phone").slideToggle();
        jQuery(this).toggleClass("active");
    });

    jQuery('.sf-menu-phone').find('li.parent').append('<i class="icon-angle-down"></i>');
    jQuery('.sf-menu-phone li.parent i').on("click", function () {
        if (jQuery(this).hasClass('icon-angle-up')) {
            jQuery(this).removeClass('icon-angle-up').parent('li.parent').find('> ul').slideToggle();
        } else {
            jQuery(this).addClass('icon-angle-up').parent('li.parent').find('> ul').slideToggle();
        }
    });

});
/* END JS menu list category click call
========================================*/
/* JS click show - + 
============================================================*/
$(document).ready(function () {
    $('.wr-content-user-click').on('click', function () {
        $parent_box = $(this).closest('.wr-sh');
        //$parent_box.siblings().find('.wr-an').slideUp();
        $parent_box.find('.wr-an').slideToggle();
        $(this).toggleClass('active');
    });
});
/* END for FAQ page click
============================================================*/
/* JS Click Notifications
========================================*/
$(document).ready(function () {
    var flagnoti = false;
    $(".click-noti").click(function () {
        flagnoti = false;
        $(this).toggleClass("active");
        $(".out-box-noti").toggleClass("active");
        $(".out-box-user").removeClass("active");
        return false;

    });

    $(".out-box-noti").click(function () {
        flagnoti = true;
    }).find(".out-box-noti input").focus(function () {
        flagnoti = true;
    });

    $('body').click(function () {
        setTimeout(function () {
            if ($(".click-noti").hasClass("active") && !flagnoti) {
                $(".click-noti").click();
            }
            flagnoti = false;
        }, 200);

    });
    $(".close-click-noti").click(function () {
        $(".out-box-noti").toggleClass("active")
    });
    /* scroll an di thang mat dich nay*/
    $(window).scroll(function () {
        if ($(".out-box-noti").is(".active")) {
            $(".out-box-noti").toggleClass("active")
        }
    });
});
/* END JS Click Notifications
========================================*/
/* JS Click User
 ========================================*/
$(document).ready(function () {
    var flaguser = false;
    $(".click-user").click(function () {
        flaguser = false;
        $(this).toggleClass("active");
        $(".out-box-user").toggleClass("active");
        $(".out-box-noti").removeClass("active");
        return false;
    });

    $(".out-box-user").click(function () {
        flaguser = true;
    }).find(".out-box-user input").focus(function () {
        flaguser = true;
    });

    $('body').click(function () {
        setTimeout(function () {
            if ($(".click-user").hasClass("active") && !flaguser) {
                $(".click-user").click();
            }
            flaguser = false;
        }, 200);

    });
    $(".close-click-user").click(function () {
        $(".out-box-user").toggleClass("active")
    });
    /* scroll an di thang mat dich nay*/
    $(window).scroll(function () {
        if ($(".out-box-user").is(".active")) {
            $(".out-box-user").toggleClass("active")
        }
    });
});
/* END JS Click User
========================================*/
/* JS Click Search Mobile
 ========================================*/
$(document).ready(function () {
    var flagsmb = false;
    $(".click-search-mb").click(function () {
        flagsmb = false;
        //$( this ).toggleClass( "active" );
        $(".click-search-mb i").toggleClass("active");
        $(".out-search-top").toggleClass("active");
        $(".out-box-user").removeClass("active");
        $(".out-box-noti").removeClass("active");
        return false;
    });

    $(".out-search-top").click(function () {
        flagsmb = true;
    }).find(".out-search-top input").focus(function () {
        flagsmb = true;
    });

    $('body').click(function () {
        setTimeout(function () {
            if ($(".click-search-mb").hasClass("active") && !flagsmb) {
                $(".click-search-mb").click();
            }
            flagsmb = false;
        }, 200);

    });
    //$(".close-click-user").click(function(){ 
    //		$( ".click-search-mb" ).toggleClass("active")
    //	});
    /* scroll an di thang mat dich nay*/
    $(window).scroll(function () {
        if ($(".out-search-top").is(".active")) {
            $(".out-search-top").toggleClass("active")
        }
    });
});
/* END JS Click Search Mobile
========================================*/
/* Menu nav Mobile
========================================*/
$(document).ready(function () {
    $('.out-btn-click-nav-mobile a').on('click', function () {
        $(".out-btn-click-nav-mobile").toggleClass('active');
        $(".out-navbar").toggleClass('active');
    });
    // Click show hide sub menu mobile
    $('.click-show-sub-mb').on('click', function () {
        //$parent_box = $(this).closest('li');
        //        $parent_box.siblings().find('.nav.nav-second-level').slideUp(600);
        //        $parent_box.find('.nav.nav-second-level').slideToggle("600");
        //        $(this).toggleClass("active").siblings().removeClass('active');
        $('.click-show-sub-mb.active').not(this).removeClass('active');
        $parent_box = $(this).closest('li');
        $parent_box.siblings().find('.nav.nav-second-level').slideUp("600");
        $parent_box.find('.nav.nav-second-level').slideToggle("600");
        $(this).toggleClass("active");
    });

});

/* END Menu nav Mobile
========================================*/

/* JS Data Table 
========================================*/
$(document).ready(function () {
    var table = $('#example').DataTable({
        responsive: true,
        // hien thi 100 row
        length: 100,
        //paging: false,

		/*scroll ----
		"scrollY":        "500px",
        "scrollCollapse": true,
		"paging":         false */

		/* Select row ---- 
		 select: true,*/
        /* Select row  multi---- */
        select: {
            style: 'multi'
        },
        /* Button PDF CSV DOC .... */
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            //'csvHtml5',
            //'pdfHtml5',
            {
                extend: 'pdfHtml5',
                download: 'open'
            }
        ]
    });

    new $.fn.dataTable.FixedHeader(table);
});
 /* END JS Data Table
 ========================================*/