# Notepad++ slow typing and high CPU usage

This can be caused by the function completion scanner if its character limit is set to more than 1.

## Symptoms

Typing is slow. If you hold down a letter key, the characters don't appear until you release the key.
During key-hold, N++ will appear to be using a high portion of CPU.

## Solution

 * In Notepad++, open Settings menu, Preferences...
 * Go to Auto-Completion
 * Where it says 'From 3th character' (or whatever), click the number, change it to 1
 * You can close the box and test the changes right away, it should be responsive again.
 
## Bonus

If you don't use function completion or parameter completion that much, then turn them off
in that settings dialog for a greater performance boost.

*Written 2016-01-08*