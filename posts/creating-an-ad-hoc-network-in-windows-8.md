# Creating an ad hoc network in Windows 8.1

On Windows 8 and 8.1, you can host a wireless network so that multiple PCs can play a LAN game or share files. Open a new command prompt as administrator:

	netsh wlan set hostednetwork mode=allow ssid=MyWirelessNetwork key=MyWirelessNetworkPassword1111
	
	netsh wlan start hostednetwork
	
Then when you want to stop sharing

	netsh wlan stop hostednetwork
	
Simple!

*Written 2015-04-18*
