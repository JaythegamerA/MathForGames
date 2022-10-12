using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;
using MathLibrary;



namespace GameFramework
{
    public class GameObject
    {
        //  The position of this object, relative to its parent
        public Vector3 LocalPosition { get; set; } = new Vector3(0, 0, 1);
        //  The rotation of this object, relative to its parent
        public float LocalRotation { get; set; } = 0.0f;
        //  The scale of this object, relative to its parent
        public Vector3 LocalScale { get; set; } = new Vector3(1, 1, 1);

        #region GameObject Hierarchy

        //reference to the parent object
        protected GameObject parent = null;

        //get/set for parent object
        public GameObject Parent
        {
            get
            {
                //  will return the parent, or null if none
                return parent;
            }
            set
            {
                //  Check if this object already has a parent:
                if (this.parent != null)
                {
                    //  remove ourselves from the current parents children
                    this.parent.children.Remove(this);
                }
                //then add us to the new parent
                //  Check if this object already has a parent:
                if (value != null)
                {
                    value.children.Add(this);
                }
                parent = value;

            }
        }

        //  add/remove to this list when this object gains/loses children
        protected List<GameObject> children = new List<GameObject>();

        //  return the number of children
        public int ChildCount
        {
            get { return children.Count; }
        }

        //  provides a child at the given index
        public GameObject GetChild(int index)
        {
            //returns child at given index
            return children[index];
        }

        //  ...

        //  returns your world matrix
        public Matrix3 GlobalTransform
        {
            get
            {
                //  if not, just return your local matrix
                if (parent == null)
                {
                    return LocalTransform;
                }
                else
                {
                    //  Otherwise, we have a parent! Yay! Joyous day!
                    //  Combine your parent matrix w/ your local matrix (parent * child)
                    return parent.LocalTransform * LocalTransform;
                }
            }
        }
        #endregion

        public Matrix3 LocalTransform
        {
            //READ ONLY, won't be supporting assignment
            get
            {
                return Matrix3.CreateTranslation(LocalPosition) *
                    Matrix3.CreateRotateZ(LocalRotation) *
                    Matrix3.CreateScale(LocalScale.x, LocalScale.y);
            }
        }

        //
        //  Transformation
        //

        //  Shifts the object on the x and y-axes by the given amount
        public void Translate(float x, float y)
        {
            LocalPosition += new Vector3(x, y, 0);
        }

        //  Rotates the object on the z-axis by the given amount
        public void Rotate(float radians)
        {
            LocalRotation += radians;
        }

        //  Adds to the scale of the object on the x and y axes by the given amounts
        public void Scale(float xScalar, float yScalar)
        {
            LocalScale += new Vector3(xScalar, yScalar, 0);
        }

        //
        //  Gameplay Events
        //

        //  Updates the object
        public void Update(float deltaTime)
        {
            OnUpdate(deltaTime);
            //  Call update on all of its children
            foreach (var child in children)
            {
                child.Update(deltaTime);
            }
        }

        //  Draws the object to the screen
        public void Draw()
        {
            OnDraw();
            //  call draw on all of its children
            foreach (var child in children)
            {
                child.Draw();
            }
        }

        //  Override in derived types to implement object-specific update logic
        protected virtual void OnUpdate(float deltaTime)
        {
            //intentionally blank
        }

        //  Override in derived types to implement object-specific drawing logic
        protected virtual void OnDraw()
        {
            //intentionally blank
        }
    }
}