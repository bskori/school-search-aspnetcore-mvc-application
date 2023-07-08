
$(document).ready(function () {
    var sliderwrapper = $('.slider-wrapper');
    var slideritems = $('.slider-item');
    var slidewidth = slideritems.first().outerWidth();
    var currentindex = 0;
    var totalitems = slideritems.length;

    function clonecards() {
        var cloneditems = slideritems.clone();
        sliderwrapper.append(cloneditems);
    }

    function slidetocurrent() {
        var translatex = -currentindex * slidewidth;
        sliderwrapper.css('transition', 'transform 0.6s ease');
        sliderwrapper.css('transform', 'translateX(' + translatex + 'px)');
    }

    function nextslide() {
        currentindex++;
        if (currentindex >= totalitems) {
            
            currentindex = 0;
            
            sliderwrapper.css('transition', 'none');
            sliderwrapper.css('transform', 'translateX(0)');
            
            setTimeout(function () {
                
                sliderwrapper.css('transition', 'transform 0.6s ease');
                
                slidetocurrent();
            }, 0);
        } else {
            slidetocurrent();
        }
    }

    function prevslide() {
        currentindex--;
        if (currentindex < 0) {
            
            currentindex = totalitems - 1;
            
            var translatex = -totalitems * slidewidth;
            sliderwrapper.css('transition', 'none');
            sliderwrapper.css('transform', 'translateX(' + translatex + 'px)');
           
            setTimeout(function () {
              
                sliderwrapper.css('transition', 'transform 0.6s ease');
                
                slidetocurrent();
            }, 0);
        } else {
            slidetocurrent();
        }
    }

    function startautoslide() {
        setInterval(function () {
            clonecards();
            nextslide();
        }, 3000);
    }

    $('.slider-next-btn').click(function () {
        clonecards();
        nextslide();
    });

    $('.slider-prev-btn').click(function () {
        clonecards();
        prevslide();
    });

    startautoslide();
});
