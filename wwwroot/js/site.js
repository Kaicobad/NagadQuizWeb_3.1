
$('.carousel').slick({
    speed: 500,
    slidesToShow: 1.2,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 2000,
    dots: false,
    infinite: false,
    responsive: [{
        breakpoint: 1024,
        settings: {
            slidesToShow: 2,
            slidesToScroll: 1,
            infinite: false,
            autoplay: true,
            // centerMode: true,

        }

    }, {
        breakpoint: 800,
        settings: {
            slidesToShow: 1.2,
            slidesToScroll: 2,
            dots: false,
            infinite: false,
            autoplay: true,

        }
    }, {
        breakpoint: 480,
        settings: {
            slidesToShow: 1.2,
            slidesToScroll: 1,
            dots: false,
            infinite: false,
            autoplay: true,
            autoplaySpeed: 2000,
        }
    }]
});
