INSERT INTO HyperplayRealmDB.dbo.Roles (Name, Description)
VALUES
    ('User', 'Basic role with limited access to the application.'),
    ('Admin', 'Elevated permissions to manage users, settings, and content.'),
    ('Moderator', 'Role with permissions to moderate content but without full administrative access.'),
    ('Guest', 'Role for users with minimal access, typically for non-logged-in users or restricted access.'),
    ('SuperAdmin', 'Highly privileged role with full control over the application and system settings.');
