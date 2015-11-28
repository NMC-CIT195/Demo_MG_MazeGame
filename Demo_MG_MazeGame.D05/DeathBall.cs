using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Demo_MG_MazeGame
{
    public class DeathBall
    {
        #region ENUMS

        #endregion

        #region FIELDS

        private ContentManager _contentManager;
        private Texture2D _sprite;
        private int _spriteWidth;
        private int _spriteHeight;
        private Vector2 _position;
        private Vector2 _startingPosition;
        private Vector2 _endingPosition;
        private bool _loop;
        private Vector2 _center;
        private int _speedHorizontal;
        private int _speedVertical;
        private Rectangle _boundingRectangle;
        private bool _active;

        #endregion

        #region PROPERTIES

        public ContentManager ContentManager
        {
            get { return _contentManager; }
            set { _contentManager = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                _center = new Vector2(_position.X + (_spriteWidth / 2), _position.Y + (_spriteHeight / 2));
                _boundingRectangle = new Rectangle((int)_position.X, (int)_position.Y, _spriteWidth, _spriteHeight);
            }
        }

        public bool Loop
        {
            get { return _loop; }
            set { _loop = value; }
        }

        public Vector2 EndingPosition
        {
            get { return _endingPosition; }
            set { _endingPosition = value; }
        }

        public Vector2 StartingPositiion
        {
            get { return _startingPosition; }
            set { _startingPosition = value; }
        }

        public Vector2 Center
        {
            get { return _center; }
            set { _center = value; }
        }

        public int SpeedHorizontal
        {
            get { return _speedHorizontal; }
            set { _speedHorizontal = value; }
        }

        public int SpeedVertical
        {
            get { return _speedVertical; }
            set { _speedVertical = value; }
        }

        public Rectangle BoundingRectangle
        {
            get { return _boundingRectangle; }
            set { _boundingRectangle = value; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// instantiate a new DeathBall object
        /// </summary>
        /// <param name="contentManager">game content manager object</param>
        /// <param name="spriteName">file name of sprite</param>
        /// <param name="position">vector position of Player</param>
        public DeathBall(
            ContentManager contentManager,
            string spriteName,
            Vector2 startingPosition
            )
        {
            _contentManager = contentManager;
            _startingPosition = startingPosition;
            _position = startingPosition;

            // load the Player images in for the different directions
            _sprite = _contentManager.Load<Texture2D>("death_ball");

            _spriteWidth = _sprite.Width;
            _spriteHeight = _sprite.Height;

            // set the initial center and bounding rectangle for the player
            _center = new Vector2(startingPosition.X + (_spriteWidth / 2), startingPosition.Y + (_spriteHeight / 2));
            _boundingRectangle = new Rectangle((int)startingPosition.X, (int)startingPosition.Y, _spriteWidth, _spriteHeight);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// draw death ball
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // only draw the player if it is active
            if (_active)
            {
                spriteBatch.Draw(_sprite, _position, Color.White);
            }
        }

        /// <summary>
        /// update death ball
        /// </summary>
        public void Update()
        {
            // death ball is moving right horizontally
            if (_speedHorizontal != 0)
            {
                if (_position.X > _endingPosition.X)
                {
                    // change directions
                    _speedHorizontal = - _speedHorizontal;
                }
                else if (_position.X < _startingPosition.X)
                {
                    // change directions
                    _speedHorizontal = - _speedHorizontal;
                }
            }

            // death ball is moving vertically
            if (_speedVertical != 0)
            {
                if (_position.Y > _endingPosition.Y)
                {
                    // change directions
                    _speedVertical = - _speedVertical;
                }
                else if (_position.Y < _startingPosition.Y)
                {
                    // change directions
                    _speedVertical = -_speedVertical;
                }
            }

            // update death ball position
            Position += new Vector2(SpeedHorizontal, SpeedVertical);
        }

        #endregion
    }
}

