using System.Text.Json;
using Microsoft.AspNetCore.Identity;

namespace AuthDemo;
public class User
{ 
	required public string Username { get; set; } 
	required public string PasswordHash { get; set;}


	const string filePath = "data/users.json";

	// Validate a user
	public static User? Validate(string username, string pass)
	{
		if (!File.Exists(filePath))
			return null;

		// Read user data from JSON file
		var json = File.ReadAllText(filePath);
		var users = JsonSerializer.Deserialize<List<User>>(json) ?? [];

		// Check if the username exists
		var user = users.FirstOrDefault(u => u.Username == username);
		if (user is null) 
			return null;

		// Check if the password matches
		var hasher = new PasswordHasher<User>();
		var result = hasher.VerifyHashedPassword(user, user.PasswordHash, pass);
		return result == PasswordVerificationResult.Failed ? null : user;
	}

}