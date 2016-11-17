using UnityEngine;
using System.Collections;

public interface Movable {

	/// <summary>
	/// Determines whether this instance is moving.
	/// </summary>
	/// <returns><c>true</c> if this instance is moving; otherwise, <c>false</c>.</returns>
	bool IsMoving();

	/// <summary>
	/// Move the specified Instance by xDir and yDir.
	/// </summary>
	/// <param name="xDir">X dir.</param>
	/// <param name="yDir">Y dir.</param>
	bool Move(int xDir, int yDir);
}
