This repository shows some demo illusion games from our paper: 
[Game Illusionization: A Workflow for Applying Optical Illusions to Video Games](https://dl.acm.org/doi/abs/10.1145/3472749.3474824)
For more detail, please refer to the paper!!

3 optical illusions are adapted into games to spice them up and 2 unity package provided for user to add the illusion into their games.

## Munker illsion
The perception of color is influenced by the neighborhood.
Illusion detail: https://michaelbach.de/ot/lum-white/index.html

### Description
Demo Game
1. press Start to start the game
2. using 'W', 'S', 'A', 'D' to control the character.
3. collect cube with the same color and dodge the cube with different color.
4. the stars will force you change color, be aware!
 
Munker package
1. Create a GameObject and drag the Stripe Creator on that GameObject.
2. Change the camera projection to Orthographic, and adjust the position and rotation
3. Press Play mode 
4. With basic mode in Stripe Creator script, developers can simply slide the effect intensity bar to adjust the strength of munker illusion.
5. If developers is not satisified with the effect, they can check the advance setting and adjust more parameter of munker illusion

## Poggendorff illusion
The alignment of a line would be affected by obstacle.
Detail: https://michaelbach.de/ot/ang-poggendorff/index.html

### Description
Demo Game
1. press Start to start the game
2. Players take turn hit the ball
3. Poggendorff illusion button will turn red color if one player is two points behind the other.
4. Press the ESC key to enter paused menu.

Poggendorff package
1. Press play to enter play mode of unity 
2. For occluder, you can change the color, the width, the length of the occluder
3. You can change the line width of both right line and intervene line.
3. For the right line, you can only change the left side length
4. for the intervene line, you can change the left side length and right side length
5. for the intervene line, you can change the angle, position, color or add more intervene line to imporve the effect of Poggendorff illusion.

## Tusi motion 
Objects' motion would be wrongly interpreted by the other object's motion.
Detail: https://michaelbach.de/ot/mot-Tusi/index.html

### Description
We added this illusion into famous unity tutorial game- Survival Shooter
https://learn.unity.com/project/survival-shooter-tutorial

Demo Game:
1. using 'W', 'S', 'A', 'D' to control the character.
2. collecting star or cube on the floor to gain special weapon
3. click left mouse buton to fire, press "space" to shoot the special weapon
4. observe the motion of special weapon
