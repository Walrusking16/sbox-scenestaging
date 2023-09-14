﻿using Sandbox;
using Sandbox.Diagnostics;

[Title( "Sphere Collider" )]
[Category( "Physics" )]
[Icon( "panorama_fish_eye", "red", "white" )]
public class SphereColliderComponent : GameObjectComponent, PhysicsComponent.IBodyModifier
{
	[Property] public float Radius { get; set; } = 10.0f;
	[Property] public Surface Surface { get; set; }

	public override void DrawGizmos()
	{
		Gizmo.Draw.Color = Color.White.WithAlpha( Gizmo.IsChildSelected ? 0.5f : 0.1f );
		Gizmo.Draw.LineSphere( new Sphere( 0, Radius ) );
	}

	public override void OnEnabled()
	{

	}

	public override void OnDisabled()
	{

	}

	public void ModifyBody( PhysicsBody body )
	{
		var tx = body.Transform.ToLocal( GameObject.WorldTransform );

		// todo position relative to body
		var shape = body.AddSphereShape( tx.Position, Radius );
		shape.SurfaceMaterial = Surface.ResourceName;
	}
}
