# PHP errors not displaying on OVH even though display_errors = on

This happens because OVH uses an optimised PHP infrastructure known as PHP-FPM. This system does not respect `php.ini` files
like PHP-CGI does.

Instead, there are settings in `.ovhconfig` which determine how PHP-FPM handles things like errors,
based on an `environment` setting. When `environment = production`, errors are not displayed. 

There are a few solutions:

## 1. Change the .ovhconfig environment

Download the `.ovhconfig` file from your web hosting root.
Change the `environment` flag from `production` to `development`.
	
## 2. Disable PHP-FPM

You can modify the `.ovhconfig` to force the use of PHP-CGI instead.
This will allow you to use `php.ini` files. The new content for `.ovhconfig` will be:

	app.engine=phpcgi
	app.engine.version=5.4
	
**N.b.** that I have changed this advice from the documented version in which OVH said you should set the engine version to `AUTO`, but this will seemingly give you a very regressive PHP version of 4.4.9!!

## 3. Manually force errors to display

This is the least elegant solution. At the start of the PHP file you want to debug, add:

	ini_set('display_errors', 1); 
	error_reporting(E_ALL);

## Source

[Enable PHP optimisation with OVH's Shared Hosting](https://www.ovh.co.uk/en/g1175.activer_loptimisation_php_sur_son_hebergement_mutualise_ovh)
