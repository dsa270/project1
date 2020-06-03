
JECRC_PMall = {};

JECRC_PMall.registerNamespace = function() {
    var a = arguments, o = null, i, j, d, rt;
    for (i = 0; i < a.length; ++i) {
        d = a[i].split(".");
        rt = d[0];
        eval("if (typeof " + rt + " == \"undefined\"){" + rt + " = {};} o = " + rt + ";");
        for (j = 1; j < d.length; ++j) {
            o[d[j]] = o[d[j]] || {};
            o = o[d[j]]
        }
    }
}

JECRC_PMall.registerNamespace('JECRC_PMall.Controls');

JECRC_PMall.Controls.ContentScroller = function(ieScroller, nsScroller0, nsScroller1, scrollSpeed, scrollDirection) {
    //Alias for the control.
    var CS = JECRC_PMall.Controls.ContentScroller;

    //Instance Members
    this.scrollerWidth = 0;
    this.scrollerHeight = 0;
    this.scrollerSpeed = (document.all) ? scrollSpeed : Math.max(1, scrollSpeed - 1);
    this.scrollDirection = scrollDirection;
    this.pauseit = 1;
    this.lastValue = null;
    this.copyspeed = scrollSpeed;
    this.actualheight = ''
    this.actualwidth = ''

    this.cross_scroller = (CS.iedom ? (document.getElementById ? document.getElementById(ieScroller) : document.all.ieScroller) : '');
    this.ns_scroller = (!CS.iedom ? document.nsScroller0.document.nsScroller1 : '');

    this.pausespeed = (this.pauseit == 0) ? this.copyspeed : 0;


    //Instance Methods
    CS.prototype.populate = function() {

        if (CS.iedom) {
            //      Incorrect way of finding content sizes.
            //		actualheight = cross_scroller.offsetHeight
            //		actualwidth = cross_scroller.offsetWidth

            // Correct way of finding Actual Content sizes.
            this.actualheight = this.getContentHeight(this.cross_scroller)
            this.actualwidth = this.getContentWidth(this.cross_scroller)

            // Visible content size. Use explicit size if one has been set (clientHeight != 0), else use the actual content size.
            var parent = this.cross_scroller.parentElement;
            if (parent == null)
                parent = this.cross_scroller.parentNode;

            this.scrollerHeight = this.getVisibleHeight(parent);
            if (parent.clientHeight == 0)
                parent.style.height = this.scrollerHeight + "px";

            this.scrollerWidth = this.getVisibleWidth(parent);
            if (parent.clientWidth == 0)
                parent.style.width = this.scrollerWidth + "px";

            if (this.scrollDirection == 'Vertical' || this.scrollDirection == 'BottomToTop')
                this.lastValue = parseInt(this.scrollerHeight) + "px"
            else if (this.scrollDirection == 'TopToBottom')
                this.lastValue = (-1) * parseInt(this.actualheight) + "px"
            else if (this.scrollDirection == 'Horizontal' || this.scrollDirection == 'RightToLeft')
                this.lastValue = parseInt(this.scrollerWidth) + "px"
            else if (this.scrollDirection == 'LeftToRight')
                this.lastValue = (-1) * parseInt(this.actualwidth) + "px"

            //		//Scroll Inner Html is already available now from code-behind.
            //		cross_scroller.innerHTML = scrollerContent
        }
        else if (document.layers) {
            this.actualheight = this.ns_scroller.document.height;
            this.actualwidth = this.ns_scroller.document.width;

            if (this.scrollDirection == 'Vertical' || this.scrollDirection == 'BottomToTop')
                this.lastValue = parseInt(this.scrollerHeight)
            else if (this.scrollDirection == 'TopToBottom')
                this.lastValue = (-1) * parseInt(this.actualheight)
            else if (this.scrollDirection == 'Horizontal' || this.scrollDirection == 'RightToLeft')
                this.lastValue = parseInt(this.scrollerWidth)
            else if (this.scrollDirection == 'LeftToRight')
                this.lastValue = (-1) * parseInt(this.actualwidth)

            //		//Scroll Inner Html is already available now from code-behind.
            //		ns_scroller.document.write(scrollerContent)

            this.ns_scroller.document.close()
        }

        var obj = this;

        // Scrolling starts here, if not set to None.
        if (this.scrollDirection == 'Vertical' || this.scrollDirection == 'BottomToTop')
            lefttime = setInterval(function() { obj.scrollBottomToTop(); }, 20)
        else if (this.scrollDirection == 'TopToBottom')
            lefttime = setInterval(function() { obj.scrollTopToBottom(); }, 20)
        else if (this.scrollDirection == 'Horizontal' || this.scrollDirection == 'RightToLeft')
            lefttime = setInterval(function() { obj.scrollRightToLeft(); }, 20)
        else if (this.scrollDirection == 'LeftToRight')
            lefttime = setInterval(function() { obj.scrollLeftToRight(); }, 20)
    }


    CS.prototype.scrollBottomToTop = function() {
        if (CS.iedom) {
            if (parseInt(this.lastValue) > (this.actualheight * (-1)))
                this.lastValue = parseFloat(this.lastValue) - parseFloat(this.copyspeed / 5.0)
            else
                this.lastValue = parseFloat(this.scrollerHeight)
            this.cross_scroller.style.top = Math.floor(this.lastValue) + "px";
        }
        else
            if (document.layers) {
            if (this.lastValue > (this.actualheight * (-1)))
                this.lastValue -= parseFloat(this.copyspeed / 5.0)
            else
                this.lastValue = parseFloat(this.scrollerHeight)
            this.ns_scroller.top = Math.floor(this.lastValue);
        }
    }


    CS.prototype.scrollTopToBottom = function() {
        if (CS.iedom) {
            if (parseInt(this.lastValue) < (parseInt(this.scrollerHeight)))
                this.lastValue = parseFloat(this.lastValue) + parseFloat(this.copyspeed / 5.0)
            else
                this.lastValue = (-1) * parseFloat(this.actualheight)
            this.cross_scroller.style.top = Math.floor(this.lastValue) + "px";
        }
        else
            if (document.layers) {
            if (this.lastValue < (this.scrollerHeight))
                this.lastValue += parseFloat(this.copyspeed / 5.0)
            else
                this.lastValue = (-1) * parseFloat(this.actualheight)
            this.ns_scroller.top = Math.floor(this.lastValue);
        }
    }


    CS.prototype.scrollRightToLeft = function() {
        if (CS.iedom) {
            if (parseInt(this.lastValue) > (this.actualwidth * (-1)))
                this.lastValue = parseFloat(this.lastValue) - parseFloat(this.copyspeed / 5.0)
            else
                this.lastValue = parseFloat(this.scrollerWidth)
            this.cross_scroller.style.left = Math.floor(this.lastValue) + "px";
        }
        else
            if (document.layers) {
            if (this.lastValue > (this.actualwidth * (-1)))
                this.lastValue -= parseFloat(this.copyspeed / 5.0)
            else
                this.lastValue = parseFloat(this.scrollerWidth)
            this.ns_scroller.left = Math.floor(this.lastValue);
        }
    }


    CS.prototype.scrollLeftToRight = function() {
        if (CS.iedom) {
            if (parseInt(this.lastValue) < (parseInt(this.scrollerWidth)))
                this.lastValue = parseFloat(this.lastValue) + parseFloat(this.copyspeed / 5.0)
            else
                this.lastValue = (-1) * parseFloat(this.actualwidth)
            this.cross_scroller.style.left = Math.floor(this.lastValue) + "px";
        }
        else
            if (document.layers) {
            if (this.lastValue < (this.scrollerWidth))
                this.lastValue += parseFloat(this.copyspeed / 5.0)
            else
                this.ns_scroller.left = (-1) * parseFloor(this.actualwidth)
            this.ns_scroller.left = Math.floor(this.lastValue);
        }
    }


    CS.prototype.getContentWidth = function(el) {
        //     var tmp=el.style.overflow
        //     el.style.overflow='auto'
        var w = el.scrollWidth
        //     el.style.overflow=tmp
        return w
    }

    CS.prototype.getContentHeight = function(el) {
        //     var tmp=el.style.overflow
        //     el.style.overflow='auto'
        var w = el.scrollHeight
        //     el.style.overflow=tmp
        return w
    }

    CS.prototype.getVisibleWidth = function(el) {
        // Visible content size. Use explicit size if one has been set (clientWidth != 0), else use the actual content size.
        if (el.clientWidth != 0)
            return (el.clientWidth);
        else
            return (el.scrollWidth);
    }

    CS.prototype.getVisibleHeight = function(el) {
        if (el.clientHeight != 0)
            return (el.clientHeight);
        else
            return (el.scrollHeight);
    }

}


//Alias for the control.
var CS = JECRC_PMall.Controls.ContentScroller;


//Static Members
CS.scrollers = new Array();
CS.iedom = document.all || document.getElementById;


//Static Methods
CS.startScroll = function() {
    for (i = 0; i < CS.scrollers.length; i++)
        CS.scrollers[i].populate();
}

CS.resumeScroll = function(div) {
    var scr;
    for (i = 0; i < CS.scrollers.length; i++) {
        if (CS.scrollers[i].cross_scroller == div.childNodes[0]) {
            scr = CS.scrollers[i];
            break;
        }
    }
    if (scr != null)
        scr.copyspeed = scr.scrollerSpeed;
}

CS.pauseScroll = function(div) {
    var scr;
    for (i = 0; i < CS.scrollers.length; i++) {
        if (CS.scrollers[i].cross_scroller == div.childNodes[0]) {
            scr = CS.scrollers[i];
            break;
        }
    }
    if (scr != null)
        scr.copyspeed = scr.pausespeed;
}

CS.initializeScroller = function(ieScroller, nsScroller0, nsScroller1, scrollSpeed, scrollDirection) {
    if (CS.scrollers.length == 0)
        window.onload = function() { CS.startScroll(); };

    var scr = new CS(ieScroller, nsScroller0, nsScroller1, scrollSpeed, scrollDirection);
    CS.scrollers[CS.scrollers.length] = scr;
}
