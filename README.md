# Fountain
A map painting/generating software kit for worldbuilders.

#Installation
Fountain for Windows can be downloaded for installation here: https://www.dropbox.com/s/k9mad4g3hszvsj9/Fountain_Windows.zip?dl=0

If you would like to install Fountain on a Linux or Macintosh operating system, please download and compile the source code provided using Mono. I will, at some point, include a binary for Linux, but I have no Linux machine upon which to perform testing so the task may fall to another poor, unfortunate soul.

#Tutorials
Fountain might be a bit of a headache for some people - it's designed to be very, very flexible but with that comes certain magnitudes of complexity that most people might not be willing to accept. Much of this complexity comes from the brush and effect scripting, but thankfully; much of that will be done away with if you grab brushes and effects from the tutorials or other users.

##1: The Document
A Fountain document contains renders, brushes, effects and gradients. When you save a Fountain document, the brush and effect scripts are saved to the file along with the heightmaps behind the renders and the data from your gradients.

Adding any of these four elements to a document is easy - click the appropriate tab, then type a name for the item into the combo box. Once you're happy with the name, hit enter to create a new render, brush, effect or gradient and add it to the document. A window will appear allowing you to alter the attributes of the item - this window can always be re-opened by clicking the appropriate 'Edit' option later in the same tab.

##2: Scripting
Renders and gradients are simple enough but things get trickier when dealing in brushes and effects. This is because there is no default implementation for brushes or effects in Fountain; you need to write your own or use someone elses.

##3: Painting
When painting you are equipped with two brushes; left and right. These two brushes correspond to your left and right mouse buttons respectively.