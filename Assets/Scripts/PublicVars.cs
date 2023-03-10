using System;
using System.Collections;
using System.Collections.Generic;

public static class PublicVars
{
	public enum Flag
	{
		// Clue flags
		DoorIsLocked, FoundDoorKey,
		SafeIsLocked, FoundSafeCode,
		FireplaceIsStrange, FoundBlueprints,
		RoomIsBlocked, FoundHammer,
		DrawerIsLocked, FoundDrawerKey,
		GhostIsSad, FoundGhostJournal,
		// World flags
		BasementBoardsRemoved,
		// Dialogue flags
		GameStartDialogue, GhostConvoDialogue,
		// No flag
		None
	}

	public static string previousScene = "";
	static List<Flag> _nonClueFlags;

	static List<Flag> _setFlags;
	static int _newFlags;
	static int _totalFlags = 0;

	static PublicVars()
	{
		_nonClueFlags = new List<Flag>();
		_nonClueFlags.Add(Flag.BasementBoardsRemoved);
		_nonClueFlags.Add(Flag.GameStartDialogue);
		_nonClueFlags.Add(Flag.GhostConvoDialogue);
		_nonClueFlags.Add(Flag.None);
		ResetAll();
	}

	public static bool CheckFlag(Flag flag)
	{
		return _setFlags.Contains(flag);
	}

	public static bool SetFlag(Flag flag)
	{
		bool already_set = CheckFlag(flag);
		if (!already_set)
		{
			_setFlags.Add(flag);
			if (!_nonClueFlags.Contains(flag))
			{
				_newFlags++;
				_totalFlags++;
			}
		}
		return already_set;
	}

	public static int GetNewFlagCount()
	{
		return _newFlags;
	}

	public static int GetTotalFlagCount()
	{
		return _totalFlags;
	}

	public static void ResetNewFlagCount()
	{
		_newFlags = 0;
	}

	public static void ResetAll()
	{
		_setFlags = new List<Flag>();
		_newFlags = 0;
		_totalFlags = 0;
		previousScene = "";
	}
}
