using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDrawing.UtalEngine2D_2023_1.Physics
{
    public class Rigidbody
    {
        public List<Rigidbody> CollisionStayList = new List<Rigidbody>();
        public Transform transform;
        public Vector2 lastPos;
        public List<Collider> colliders = new List<Collider>();        
        public Vector2 Velocity;
        public bool isStatic = false;

        public Vector2 force = new Vector2(0,0);
        public float mass = 1;


        public delegate void CollisionDelegate(Object o);
        public CollisionDelegate OnCollision;
        public CollisionDelegate OnCollisionStay;
        public CollisionDelegate OnCollisionExit;
        public delegate Object GetOnCollisionObjectDelegate();
        public GetOnCollisionObjectDelegate GetOnCollisionObject;

        public Rigidbody()
        {
            PhysicsEngine.allNewRigidbodies.Add(this);            
        }      
        public void SetTransform(Transform transform)
        {
            this.transform = transform;
            lastPos = transform.position;
        }
        public void CreateCircleCollider(float radius)
        {
            colliders.Add(new CircleCollider(this, radius));
        }
        public void CreateRectCollider(Vector2 size)
        {
            colliders.Add(new RectCollider(this, size));
        }

        public void Update()
        {
            if (isStatic)
            {
                return;
            }
            Vector2 accel = force*(1/mass);
            force = new Vector2(0,0);
            Velocity += accel;
            transform.position += Velocity * Time.deltaTime * PhysicsEngine.pixelsPerMeter;
        }

        public bool CheckCollision(Rigidbody otherRigid)
        {
            foreach(Collider myC in colliders)
            {
                foreach(Collider otherC in otherRigid.colliders)
                {
                    if (myC.CheckCollision(otherC))
                    {
                        if (CollisionStayList.Contains(otherC.rigidbody))
                        {
                            OnCollisionStay?.Invoke(otherRigid.GetOnCollisionObject?.Invoke());
                            otherRigid.OnCollisionStay?.Invoke(GetOnCollisionObject?.Invoke());
                        }
                        else
                        {
                            CollisionStayList.Add(otherC.rigidbody);
                            otherRigid.CollisionStayList.Add(this);
                        }
                        if(myC.isSolid && otherC.isSolid)
                        {
                            bool checkSecondColl = false;
                            Vector2 toOtherDirection = otherC.rigidbody.transform.position - transform.position;
                            if (!otherC.rigidbody.isStatic)
                            {
                                checkSecondColl = true;
                                otherC.rigidbody.transform.position = otherC.rigidbody.lastPos;
                                if (isStatic)
                                {
                                    otherC.rigidbody.Velocity = toOtherDirection.Normalized() * otherC.rigidbody.Velocity.Magnitude() * 0.9f;
                                }                               
                            }
                            if (!isStatic)
                            {
                                checkSecondColl = true;
                                transform.position = lastPos;
                                if (otherC.rigidbody.isStatic)
                                {
                                    Velocity = new Vector2(0, 0) - toOtherDirection.Normalized() * Velocity.Magnitude() * 0.9f;
                                }
                            }
                            if(!isStatic && !otherC.rigidbody.isStatic)
                            {
                                Velocity = new Vector2(0, 0) - toOtherDirection.Normalized() * Velocity.Magnitude() * (0.9f/2f);
                                otherC.rigidbody.force -= Velocity*mass;
                                otherC.rigidbody.Velocity = toOtherDirection.Normalized() * otherC.rigidbody.Velocity.Magnitude() * (0.9f/2f);
                                force -= otherC.rigidbody.Velocity*otherC.rigidbody.mass;
                            }

                            if(checkSecondColl && myC.CheckCollision(otherC))
                            {
                                if (!otherC.rigidbody.isStatic)
                                {
                                    otherC.rigidbody.transform.position += toOtherDirection * Time.deltaTime*5;
                                    otherC.rigidbody.force += toOtherDirection * Time.deltaTime * 5;
                                }
                                if (!isStatic)
                                {
                                    transform.position -= toOtherDirection * Time.deltaTime*5;
                                    force -= toOtherDirection * Time.deltaTime * 5;
                                }
                            }

                        }
                        if (OnCollision != null && otherRigid.GetOnCollisionObject != null)
                        {
                            OnCollision(otherRigid.GetOnCollisionObject());                            
                        }
                        if(GetOnCollisionObject != null && otherRigid.OnCollision != null)
                        {
                            otherRigid.OnCollision(GetOnCollisionObject());
                        }
                        return true;
                    }
                    else
                    {
                        if (CollisionStayList.Contains(otherRigid))
                        {
                            OnCollisionExit?.Invoke(otherRigid.GetOnCollisionObject?.Invoke());
                            CollisionStayList.Remove(otherRigid);
                            otherRigid.OnCollisionExit?.Invoke(GetOnCollisionObject?.Invoke());
                            otherRigid.CollisionStayList.Remove(this);
                        }
                    }
                }
            }
            return false;
        }
    }
}
