# BSOD when joining mobile hotspot

Whenever I join the WiFi from my phone's Internet Sharing feature, my Windows 8.1 PC suffers a Blue Screen of Death (Kernel Panic). This is because you need to enable FIPS in the network's security settings, which I can't do because the BSOD is *immediate* when I connect to the phone. Apparently this issue affects all internet sharing phones, including Android.

## Solution

I got this solution from a [comment on a blog post about the issue][1]

 * Disable the WiFi on your PC/laptop (for me, this is `Fn+F12`; F12 has a picture of a mast on it)
 * Change the SSID of your phone's network (On Lumia: Settings, Internet Sharing, then tap the pencil icon)
 * Open 'Network and Sharing Center' on your PC
 * Click 'Set up a new connection or network'
 * Click 'Manually connect to a wireless network'
 * Enter the SSID from your phone, and the security settings (the security type is probably WPA2-Personal)
 * Click Next
 * Click 'Change connection settings'
 * Go to the Security tab
 * Click 'Advanced Settings' (if you don't see it, change the security type field)
 * Tick 'Enable Federal Information Processing Standards'
 * Click OK, then OK, then Close
 * Turn your Internet Sharing on
 * Turn your PC WiFi back on
 
This worked completely for me and now I can join my phone's network again, yay!

[1]: http://timyocum.blogspot.co.uk/2013/10/windows-81-bsod-while-connected-to-my.html?showComment=1444668442839#c5523525402180672942