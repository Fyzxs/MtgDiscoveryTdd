# To Developers
This file will help all of us stay in sync.

## Visual Studio Configuration
Unfortunately there are some useful bits that the tool files can't take care of.
Here's what needs to happen IN visual studio to configure a few very useful bits that help keep the code in shape.

MENU > Analyze > Code Cleanup > Configure Code Cleanup  
Select or create a profile and put the following items into the top
* Apply object creation preferences
* Add accessibility modifiers
* Order modifiers
* Make field readonly
* Apply object/collection initialization preferences
* Format document
* Remove unnecessary imports or usings
* Sort imports or usings
* Apply parentheses preferences
* Apply statement after block preferences (experimental)
* Apply namespace matches folder preferences
* Apply blank line preferences (experimental)
* Remove unused suppressions
* Apply string interpolation preferences
* Apply tuple name preferences
* Apply 'var' preferences
* Apply expresssion/block body preferences
* Apply inline 'out' variable preferences
* Apply method group conversion preferences
* Apply namespace preferences
* Apply new() preferences
* Apply using statement preferences

Then use Analyze > Code Clean up > Run Code Cleanup (Profile YOU added thigns to) on Solution. No changes should happen. If so... we have to update something.

NEXT
Tools > Options > Text Editor > Code Cleanup | Select the Profile you added things to. Check "Run code cleanup profile on save".
