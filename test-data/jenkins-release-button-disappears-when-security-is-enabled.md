# Jenkins Release button disappears when security is enabled

I just installed the Active Directory plugin and set our Jenkins server to secure using it. Then, all of the 'Release' buttons on our projects disappeared. If this happens to you, it is probably because you have set 'Logged-in users can do anything' and for some reasons 'anything' doesn't encompass 'Release'!

## Solution

![Jenkins authorization matrix](./posts/jenkins/matrix.png)

 * Go to Jenkins > Manage Jenkins > Configure Global Security (`/configureSecurity`)
 * Change the **Authorization** setting from 'Logged-in users can do anything' to 'Matrix based security'
 * Add the user 'authenticated' and tick every box in that row
 * Do not tick any boxes in Anonymous row unless you have a reason to do so
 * Click the Save button in the page footer
 
You should be all set now, and Release buttons will re-appear on the projects where Release build is configured!

**Jenkins version 1.626**

**Edit:** I found the bug tracker entry for this, [Jenkins bug 28132](https://issues.jenkins-ci.org/browse/JENKINS-28132) and it turns out that the workaround is exactly what I described above :)

*Written 2015-08-26*
