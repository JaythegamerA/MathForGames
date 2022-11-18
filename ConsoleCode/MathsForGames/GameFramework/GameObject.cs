using MathLibrary;
using Raylib_cs;

namespace GameFramework
{
    public class GameObject
    {

        public Texture2D sprite;

       

        protected GameObject parent = null;
        public GameObject Parent
        {
            get => parent;
            set
            {
                if (parent != null)
                {
                    parent.children.Remove(this);
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
            get
            {
                return children.Count;
            }
        }

        public GameObject GetChild(int index)
        {
            return children[index];
        }


        public Vector3 localPosition { get; set; }
        public float localRotation { get; set; }
        public Vector3 localScale { get; set; } = new Vector3(1, 1, 1);

        public Vector3 targetDirection { get; set; }

        public Matrix3 LocalTransform
        {
            get
            {
                return Matrix3.CreateTranslation(localPosition) *
                    Matrix3.CreateRotateZ(localRotation) *
                    Matrix3.CreateScale(localScale.x, localScale.y);
            }
        }

        public Matrix3 GlobalTransform
        {
            get
            {
                if (parent != null)
                {
                    return parent.GlobalTransform * LocalTransform;
                }
                else
                {
                    return LocalTransform;
                }
            }
        }

        public void Translate(float x, float y)
        {
            localPosition += new Vector3(x, y, 0);
        }

        public void Rotate(float rot)
        {
            localRotation += rot;
        }

        public void Scale(float xScaler, float yScaler)
        {
            localScale += new Vector3(xScaler, yScaler, 0);
        }


        public void Update(float deltaTime)
        {
            OnUpdate(deltaTime);

            foreach (var child in children)
            {
                child.Update(deltaTime);
            }
        }

        protected virtual void OnUpdate(float deltaTime)
        {

        }

        public void Draw()
        {
            OnDraw();

            foreach (var child in children)
            {
                child.Draw();
            }
        }

        protected virtual void OnDraw()
        {

        }
    }
}