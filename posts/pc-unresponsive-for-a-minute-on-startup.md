# PC unresponsive for a minute on startup, wake, or resume

You may want to uninstall Hyper-V.

## Symptoms

 * When you turn your PC on and log in, before the desktop loads, you see a frozen mouse cursor on a black screen for 1 to 2 minutes
 * When you resume or wake your PC and log in, after working fine for a few seconds, the screen will freeze for 1 to 2 minutes

I have Hyper-V on my development laptop because Visual Studio installs it for Windows Phone emulators, and I am a Windows Phone developer. For me, this problem was caused by Hyper-V monitoring a storm of network events during wake (I don't fully understand why). Causes for this problem will obviously vary.

*Keyboard shortcuts in this article are for Windows 8+*

## If you have Hyper-V

 * Open event viewer (`Win` + `X`, `V`)
 * Navigate to Windows Logs / System
 * Filter it down to only Warnings, Errors, and Criticals
 * Sort by Date descending
 
If you have a lot of events thrown by Hyper-V which talk about media being connected or disconnected on your network card, proceed to fix the problem. If not, sorry. Maybe you haven't looked at these events before and it will help you diagnose the problem?

## Removing Hyper-V

This is a naive solution, but I don't actually use Hyper-V, I just deploy straight to my Lumia phone over USB. If you don't want to remove it, you're on your own.

 * Open Windows Features (`Win` + `W`, type 'features', select 'Turn Windows features on or off')
 * Navigate to Hyper-V
 * Untick it, and make sure it is totally clear, including all sub-components
 * Click OK
 * Do some waiting
 * When it prompts to Restart, do it
 * When your PC comes back on, you may need to enter your password manually (i.e. biometrics disabled), and the PC will then restart *again*
 * Your PC is now fixed (hopefully)
 
## Added bonus

Your cluttered Network Connections settings will now have a lot less entries! All the virtual network ports installed by Hyper-V will be gone.

-----

Have a successful day. Disucssion @SteGriff on twitter.