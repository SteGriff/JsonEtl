# Getting Started with Masonry JS

[Masonry JS](http://masonry.desandro.com/) is a powerful library for making reactive tile layouts so that content boxes and images can shuffle themselves around your page layout to make best use of space.

## 1. Create an HTML page and add some boxes

Create an HTML template and add some basic stuff like this. You can use any class names for `container` and `item`, they just have to match the CSS classes which you're about to make.

	<!doctype html>
	<html>
	<head>
	  <meta charset="utf-8">
	  <title>Masonry</title>
	  <style>

	  </style>
	</head>
	<body>

	<div class="container">
		<div class="item w2">1</div>
		<div class="item w2">2</div>
		
		<div class="item w2 h3">3</div>
		<div class="item w2 h3">4</div>
		
		<div class="item w2 h2">6</div>
		
		<div class="item">7</div>
		<div class="item">8</div>
	</div>

	</body>
	</html>


## 2. Add some CSS

You can the CSS inline in the `style` block or using a `link` tag (but you probably already knew that):

	* {
	  box-sizing: border-box;
	}

	.container {
	  background: #EEE;
	  width: 50%;
	  margin-bottom: 20px;
	}

	.item {
	  width:  60px;
	  height: 60px;
	  float: left;
	  background: #09F;
	  padding: 10px;
	  margin: 0 10px 10px 0;
	}

	.item.w2 { width: 130px; }
	.item.w3 { width: 200px; }
	.item.w4 { width: 270px; }

	.item.h2 { height: 130px; }
	.item.h3 { height: 200px; }
	.item.h4 { height: 270px; }

### Note

I have chosen to set a margin-left on the grid items because I think it makes it easier to tesselate output. The Masonry guide recommends passing a [gutter](http://masonry.desandro.com/options.html#gutter) parameter into the JS initialisation (below).

## 3. Setup the JS
	
After your container `div`, add the JS references to get jQuery and Masonry:

	<script src="http://code.jquery.com/jquery-2.1.4.min.js"></script>
	<script src="http://cdnjs.cloudflare.com/ajax/libs/masonry/3.3.0/masonry.pkgd.min.js"></script>

	<script>
		$('.container').masonry({
		  itemSelector: '.item',
		  columnWidth: 70,
		  transitionDuration: '0.2s'
		});
	</script>

### Important Notes

* The `columnWidth` parameter should match `.item.width + .item.margin-left` from your CSS;

* The selector in `$('.container')` needs to match whatever class you actually put on your container;

* The `itemSelector` needs to match whatever class you actually put on your grid items.

## You're ready to go!

Open the page and resize it using `Ctrl+Scroll`, or the responsive layout tools. When items would become too big for the container, they fold underneath instead! Cool.

### Troubleshooting

 * If you're not connected to the internet, you won't be able to download the JavaScript references, so it won't work;
 * Check that your CSS classes match up as described;

## Appendix: Nice box sizes

OK, in our example, the basic size for an item is 60px:

	.item {
	  width:  60px;
	  height: 60px;
	  margin: 0 10px 10px 0;
	  ...

...but what I'll call the "real size" is 70px, because we add on the `margin-left` for each element.

To come up with your `.item.wn` classes, first imagine that there is a `w1` class (you could even make it, for completeness sake) then, add on your "real size" (70px) each time you go up the scale:

	.item.w1 { width: 60px; } /* Doesn't have to exist */
	.item.w2 { width: 130px; } /* That's 60 + 70 */
	.item.w2 { width: 200px; } /* That's 130 + 70 */
	
## End

Hope this helps!

*Written 2015-06-11*
