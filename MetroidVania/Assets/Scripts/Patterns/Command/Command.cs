using UnityEngine;
using System.Collections;

/**
 * Author: Maikel van Munsteren
 * Desc:   Base for all commands.
 * ToDo:   Not required for the current game, but; an undo function might be added for future commands.
 * */

public interface Command {
	 void Execute(GameObject obj);
}