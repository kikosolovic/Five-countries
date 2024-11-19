using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

public class DialogManager
{
    private Dictionary<string, Dictionary<string, string>> _dialog;

    public DialogManager(string filePath)
    {
        // Read and deserialize the JSON file
        string json = File.ReadAllText(filePath);
        _dialog = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json);
    }

    public string GetDialog(string dialogId, string speaker)
    {
        return _dialog.ContainsKey(dialogId) && _dialog[dialogId].ContainsKey(speaker)
            ? _dialog[dialogId][speaker]
            : "Dialog not found";
    }
}
