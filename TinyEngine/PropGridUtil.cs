using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TinyEngine
{
    class DictionaryPropertyGridAdapter<TKey, TValue> : ICustomTypeDescriptor
    {
        private OrderedDictionary<TKey, TValue> _dictionary;

        public DictionaryPropertyGridAdapter(OrderedDictionary<TKey, TValue> d)
        {
            _dictionary = d;
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return _dictionary;
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            ArrayList properties = new ArrayList();
            foreach (KeyValuePair<TKey, TValue> e in _dictionary)
            {
                properties.Add(new DictionaryPropertyDescriptor<TKey, TValue>(_dictionary, e.Key));
            }

            PropertyDescriptor[] props =
                (PropertyDescriptor[])properties.ToArray(typeof(PropertyDescriptor));

            return new PropertyDescriptorCollection(props);
        }
    }

    class DictionaryPropertyDescriptor<TKey, TValue> : PropertyDescriptor
    {
        private OrderedDictionary<TKey, TValue> _dictionary;
        TKey _key;

        internal DictionaryPropertyDescriptor(OrderedDictionary<TKey, TValue> d, TKey key)
            : base(key.ToString(), null)
        {
            _dictionary = d;
            _key = key;
        }

        public override Type PropertyType
        {
            get { return _dictionary[_key].GetType(); }
        }

        public override void SetValue(object component, object value)
        {
            _dictionary[_key] = (TValue)value;
        }

        public override object GetValue(object component)
        {
            return _dictionary[_key];
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type ComponentType
        {
            get { return null; }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public override object GetEditor(Type editorBaseType)
        {
            if (_dictionary[_key] is TinyRPG.EntityStats)
                return new EntityStatsEditor();
            else if (_dictionary[_key] is TinyRPG.LocaleEntryRef)
                return new LocaleEntryEditor();
            else if (_dictionary[_key] is TinyRPG.AssetRef)
                return new AssetRefEditor();
            else if (_dictionary[_key] is TinyRPG.Inventory)
                return new InventoryEditor();
            else if (_dictionary[_key] is TinyRPG.TinyShop)
                return new ShopRefEditor();
            else if (_dictionary[_key] is TinyRPG.EquipData)
                return new EquipDataEditor();
            return base.GetEditor(editorBaseType);
        }
    }
}