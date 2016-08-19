# Embed web pages into Powerpoint

Doing a demo? Want to include a fancy HTML5 page, maybe an interactive D3 chart? Are you technical? We're going to host your demo on GitHub (or GitHub Gist) and then embed it using an official PowerPoint extension. Some foreknowledge is required.

This is for **Office 2013**, but may be backwards (and forwards) compatible.

![Embedding a web page in PowerPoint](./posts/powerpoint/embed-web.png)

## How to do it

 * Host your web thing on GitHub Gist
 * Go to <http://rawgit.com/>, paste the address of your main html file into the field, and submit
 * Copy the CDN address which appears on the right
 * In PowerPoint, go to Insert, then Store (in Apps section of Ribbon)
 * Type 'Web Viewer' in the search and install the Microsoft Web Viewer extension
 * Insert a Web Viewer into your presentation (max out its size on the slide if you want)
 * Paste your CDN address (minus the https) into the field
 * Click the Preview button in the bottom right
 * You're good to go!
 
## Notes

This only works with https which is why it was convenient to use Gist and RawGit... SSL is expensive! :)

## Contact

Comment on twitter (@SteGriff) or email ste at this domain if you have feedback!

*Written 2015-09-09*