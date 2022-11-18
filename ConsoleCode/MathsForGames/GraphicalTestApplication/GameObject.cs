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
     
        public Vector3 LocalPosition { get; set; } = new Vector3(0, 0, 1);
    
        public float LocalRotation { get; set; } = 0.0f;
      
        public Vector3 LocalScale { get; set; } = new Vector3(1, 1, 1);

        #region GameObject Hierarchy

        
        protected GameObject parent = null;

       
        public GameObject Parent
        {
            get
            {
               
                return parent;
            }
            set
            {
                
                if (this.parent != null)
                {
               
                    this.parent.children.Remove(this);
                }
               
                if (value != null)
                {
                    value.children.Add(this);
                }
                parent = value;

            }
        }


        protected List<GameObject> children = new List<GameObject>();

       
        public int ChildCount
        {
            get { return children.Count; }
        }

     
        public GameObject GetChild(int index)
        {
          
            return children[index];
        }

    

 
        public Matrix3 GlobalTransform
        {
            get
            {
             
                if (parent == null)
                {
                    return LocalTransform;
                }
                else
                {
                
                    return parent.LocalTransform * LocalTransform;
                }
            }
        }
        #endregion

        public Matrix3 LocalTransform
        {
       
            get
            {
                return Matrix3.CreateTranslation(LocalPosition) *
                    Matrix3.CreateRotateZ(LocalRotation) *
                    Matrix3.CreateScale(LocalScale.x, LocalScale.y);
            }
        }

      
      

     
        public void Translate(float x, float y)
        {
            LocalPosition += new Vector3(x, y, 0);
        }

        
        public void Rotate(float radians)
        {
            LocalRotation += radians;
        }

        
        public void Scale(float xScalar, float yScalar)
        {
            LocalScale += new Vector3(xScalar, yScalar, 0);
        }

      
        public void Update(float deltaTime)
        {
            OnUpdate(deltaTime);
            
            foreach (var child in children)
            {
                child.Update(deltaTime);
            }
        }

       
        public void Draw()
        {
            OnDraw();
            
            foreach (var child in children)
            {
                child.Draw();
            }
        }

        
        protected virtual void OnUpdate(float deltaTime)
        {
            
        }

        
        protected virtual void OnDraw()
        {
            
        }
    }
}