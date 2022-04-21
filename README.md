# Unity project

*Inventory, Equipment, Player Stats and Buff system*

- Camera follows player with delay and has cutscene (Cinemachine)
- UI windows: Inventory, Equipment, Player Stats, Tooltip and Split stackable items
- UI bars: Health and Mana bar
- Inventory dynamic grid with flexible cell count - rows are added and removed by the need
- Picked up items can be previewed inside an inventory UI grid

- Items :
	There are 2 main types of items: - Permanent usage items - applied upon pick up, not picked up into the inventory (the suitable Debug.Log message with the item's name is sufficient)
									 - Pickup-able items - can be picked up into the inventory
	Pickup-able items :	- Equipable items
						- Non-equippable items
						- Stackable : - Stackable with stack limit (2 colors – full/not full)
									- Stackable without stack limit
						- Non-stackable
- Items provide permanent attribute bonuses to the character while they are equipped which is visible on the stats screen				
- Stackable items can be split into 2 stacks of varying amounts by the split screen that appears upon interacting with the grid cell containing the stackable item. The window contains the left and right button, editable text field and buttons "ok" and "cancel"
- Each equippable item changes the maximum or current value of attributes, by amount or percentage
- Each equippable item has durability. Current durability is spent only on equipped items per x units of the Player’s walking distance. When the durability of an item expires, the item is destroyed permanently. Visible inside Tooltip
- Consumable items, when used, change attribute values in the following manner:	- Case 1: Hold bonus value over time (example: +30% strength over 4 seconds)
																				- Case 2: Ramp value up and/or down over time (example: change dexterity from 0 to +25 in 2 seconds, and hold +25 for 5 seconds)
																				- Case 3: Change value over time in tick manner (example: Damage Health by 20 over 3 seconds / Heal health for 3 per second over 6 seconds)

*New input system used*
PC:

	- "i" or assigned button for opening/closing inventory
	- "c" or assigned button for opening/closing player stats
	- "e" or assigned button for opening/closing equip window
	- "Space" for spawning objects in green circle positions (spawns when green circle has no item - picked up) 
	- "WASD", arrows for  player movement
	- "p" to pick up items 
	- "m" to change trigger- Option 1: Pick up items by physics trigger collision - on input
							Option 2: Pick up items by player position + physics overlap circle - on input (has visual for circle)
	- Hover + "q" over stackable itemSlot opens up split window
	- Left click on the item in the grid or the equip screen forces the clicked item "into the air" and the item follows the mouse screen position
	- If the item is “in the air” and left mouse click is executed over inventory or equipment window, if the slot is of the appropriate type (equipment slot type), or it is an inventory slot, the item is slotted in the new cell
	- If all opened inventory screens get closed, and an item is "in the air", the item is returned to its previous position/slot
	- Right-click on an equipable item in the grid equips that item in the slot of the equip screen. If there was an item in that slot, it is moved to the slot in the inventory grid screen.
	- Right-click on an item in an equip slot unequips that item to the slot of the inventory grid screen, if there is any. If none, nothing.
	- Tooltip window for item’s properties (example stats: name, type, stats, image) in inventory and equipment windows upon hovering over the cell containing an item
	- Middle mouse button click on the consumable item consumes the item.
	
	
Mobile:	

	- "pick up" button to pick up Items 
	- On-screen joystick for player movement
	- Long press - moves the item “into the air”
	- On long press stop (finger release), if item was above empty inventory slot, it is slotted into that slot, if item was above the world space (there is no UI under the release position), item is dropped into the world, otherwise item is returned to the slot from which it was taken "into the air"
	- Double tap - on an item equips/unequips equipable item / uses usable, consumable item
	- Pinch gesture - zooms the camera in and out between zoom limit values
	- Tap gesture - on the item in the inventory - shows the item tooltip

	
*Unity Analytics*
Has analytics events for the following:	- On each build startup (platform, local time)
										- On Item Picked up (item name, item type)
										- On Item Equipped (item name, item slot)
										- On item Used/Consumed (item name, item type)
										- On window opened (window type)
										- On Player moved each 10 unity units total, with a maximum of 5 events for a single build execution.
										- On Player collided with the in-scene collider, with a timeout of 5 seconds minimum between 2 analytics sending events.
										
										
										