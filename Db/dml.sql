-- SQLite
select * from roles;
select * from permissions;
select * from roles_has_permissions;

pragma table_info(roles);
pragma table_info(permissions);
pragma table_info(users);
pragma table_info(roles_has_permissions);


-- Corrección de los registros de ayer
INSERT INTO roles_has_permissions (role_id, permission_id)
VALUES (1,1);