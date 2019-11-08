#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;
    using global::ZeroFormatter.Comparers;

    public static partial class ZeroFormatterInitializer
    {
        static bool registered = false;

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            if(registered) return;
            registered = true;
            // Enums
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockType?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.NullableBlockTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockType?>.Register(new NullableEqualityComparer<global::Voxels.BlockType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockModelType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockModelTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockModelType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockModelTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockModelType?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.NullableBlockModelTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockModelType?>.Register(new NullableEqualityComparer<global::Voxels.BlockModelType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockHarvestLevel>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockHarvestLevelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockHarvestLevel>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockHarvestLevelEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockHarvestLevel?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.NullableBlockHarvestLevelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockHarvestLevel?>.Register(new NullableEqualityComparer<global::Voxels.BlockHarvestLevel>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.VisibilityFlags>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.VisibilityFlagsFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.VisibilityFlags>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.VisibilityFlagsEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.VisibilityFlags?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.NullableVisibilityFlagsFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.VisibilityFlags?>.Register(new NullableEqualityComparer<global::Voxels.VisibilityFlags>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.DirIndex>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.DirIndexFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.DirIndex>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.DirIndexEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.DirIndex?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.NullableDirIndexFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.DirIndex?>.Register(new NullableEqualityComparer<global::Voxels.DirIndex>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockMeshType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockMeshTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockMeshType>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockMeshTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockMeshType?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.NullableBlockMeshTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.BlockMeshType?>.Register(new NullableEqualityComparer<global::Voxels.BlockMeshType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.CState>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.CStateFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.CState>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.CStateEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.CState?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.NullableCStateFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.CState?>.Register(new NullableEqualityComparer<global::Voxels.Networking.CState>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.ServerPacketID>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.ServerPacketIDFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.ServerPacketID>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.ServerPacketIDEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.ServerPacketID?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.NullableServerPacketIDFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.ServerPacketID?>.Register(new NullableEqualityComparer<global::Voxels.Networking.ServerPacketID>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.ClientPacketID>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.ClientPacketIDFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.ClientPacketID>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.ClientPacketIDEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.ClientPacketID?>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.NullableClientPacketIDFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Voxels.Networking.ClientPacketID?>.Register(new NullableEqualityComparer<global::Voxels.Networking.ClientPacketID>());
            
            // Objects
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockDataHolder>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockDataHolderFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.VisibilityFlagsHolder>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.VisibilityFlagsHolderFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.ChunkData>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.ChunkDataFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockDataArrayHint>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.BlockDataArrayHintFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.VisibilityFlagsArrayHint>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.VisibilityFlagsArrayHintFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.C_ChatMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.C_ChatMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.C_HandshakeMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.C_HandshakeMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.C_PongMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.C_PongMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.BaseMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.BaseMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.Networking.S_HandshakeMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Voxels.Networking.S_HandshakeMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            // Structs
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Voxels.BlockDataFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockData>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockData?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockData>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.UnityEngine.Vector3Formatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector3>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector3?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector3>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.UnityEngine.Vector2Formatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector2>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector2?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector2>(structFormatter));
            }
            // Unions
            // Generics
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.BlockData>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::Voxels.VisibilityFlags>();
        }
    }
}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class BlockDataHolderFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockDataHolder>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockDataHolder value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.SizeX);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.SizeY);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.SizeZ);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.BlockData[]>(ref bytes, startOffset, offset, 3, value.Data);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.BlockDataHolder Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new BlockDataHolderObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class BlockDataHolderObjectSegment<TTypeResolver> : global::Voxels.BlockDataHolder, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4, 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.BlockData[]> _Data;

        // 0
        public override int SizeX
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int SizeY
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int SizeZ
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override global::Voxels.BlockData[] Data
        {
            get
            {
                return _Data.Value;
            }
            set
            {
                _Data.Value = value;
            }
        }


        public BlockDataHolderObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _Data = new CacheSegment<TTypeResolver, global::Voxels.BlockData[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.BlockData[]>(ref targetBytes, startOffset, offset, 3, ref _Data);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class VisibilityFlagsHolderFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.VisibilityFlagsHolder>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.VisibilityFlagsHolder value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.SizeX);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.SizeY);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.SizeZ);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.VisibilityFlags[]>(ref bytes, startOffset, offset, 3, value.Data);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.VisibilityFlagsHolder Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new VisibilityFlagsHolderObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class VisibilityFlagsHolderObjectSegment<TTypeResolver> : global::Voxels.VisibilityFlagsHolder, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4, 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.VisibilityFlags[]> _Data;

        // 0
        public override int SizeX
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int SizeY
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int SizeZ
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override global::Voxels.VisibilityFlags[] Data
        {
            get
            {
                return _Data.Value;
            }
            set
            {
                _Data.Value = value;
            }
        }


        public VisibilityFlagsHolderObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _Data = new CacheSegment<TTypeResolver, global::Voxels.VisibilityFlags[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.VisibilityFlags[]>(ref targetBytes, startOffset, offset, 3, ref _Data);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class ChunkDataFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.ChunkData>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.ChunkData value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (6 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.IndexX);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.IndexY);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.IndexZ);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.Height);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::UnityEngine.Vector3>(ref bytes, startOffset, offset, 4, value.Origin);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.BlockDataHolder>(ref bytes, startOffset, offset, 5, value.Blocks);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.VisibilityFlagsHolder>(ref bytes, startOffset, offset, 6, value.Visibiltiy);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 6);
            }
        }

        public override global::Voxels.ChunkData Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new ChunkDataObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class ChunkDataObjectSegment<TTypeResolver> : global::Voxels.ChunkData, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4, 4, 4, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::UnityEngine.Vector3> _Origin;
        global::Voxels.BlockDataHolder _Blocks;
        global::Voxels.VisibilityFlagsHolder _Visibiltiy;

        // 0
        public override int IndexX
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int IndexY
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int IndexZ
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int Height
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override global::UnityEngine.Vector3 Origin
        {
            get
            {
                return _Origin.Value;
            }
            set
            {
                _Origin.Value = value;
            }
        }

        // 5
        public override global::Voxels.BlockDataHolder Blocks
        {
            get
            {
                return _Blocks;
            }
            set
            {
                __tracker.Dirty();
                _Blocks = value;
            }
        }

        // 6
        public override global::Voxels.VisibilityFlagsHolder Visibiltiy
        {
            get
            {
                return _Visibiltiy;
            }
            set
            {
                __tracker.Dirty();
                _Visibiltiy = value;
            }
        }


        public ChunkDataObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 6, __elementSizes);

            _Origin = new CacheSegment<TTypeResolver, global::UnityEngine.Vector3>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 4, __binaryLastIndex, __tracker));
            _Blocks = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::Voxels.BlockDataHolder>(originalBytes, 5, __binaryLastIndex, __tracker);
            _Visibiltiy = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::Voxels.VisibilityFlagsHolder>(originalBytes, 6, __binaryLastIndex, __tracker);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (6 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::UnityEngine.Vector3>(ref targetBytes, startOffset, offset, 4, ref _Origin);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::Voxels.BlockDataHolder>(ref targetBytes, startOffset, offset, 5, _Blocks);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::Voxels.VisibilityFlagsHolder>(ref targetBytes, startOffset, offset, 6, _Visibiltiy);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 6);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class BlockDataArrayHintFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockDataArrayHint>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockDataArrayHint value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.BlockData[,,]>(ref bytes, startOffset, offset, 0, value.Hint1);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.BlockDataArrayHint Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new BlockDataArrayHintObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class BlockDataArrayHintObjectSegment<TTypeResolver> : global::Voxels.BlockDataArrayHint, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.BlockData[,,]> _Hint1;

        // 0
        public override global::Voxels.BlockData[,,] Hint1
        {
            get
            {
                return _Hint1.Value;
            }
            set
            {
                _Hint1.Value = value;
            }
        }


        public BlockDataArrayHintObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _Hint1 = new CacheSegment<TTypeResolver, global::Voxels.BlockData[,,]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.BlockData[,,]>(ref targetBytes, startOffset, offset, 0, ref _Hint1);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class VisibilityFlagsArrayHintFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.VisibilityFlagsArrayHint>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.VisibilityFlagsArrayHint value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Voxels.VisibilityFlags[,,]>(ref bytes, startOffset, offset, 0, value.Hint1);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.VisibilityFlagsArrayHint Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new VisibilityFlagsArrayHintObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class VisibilityFlagsArrayHintObjectSegment<TTypeResolver> : global::Voxels.VisibilityFlagsArrayHint, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Voxels.VisibilityFlags[,,]> _Hint1;

        // 0
        public override global::Voxels.VisibilityFlags[,,] Hint1
        {
            get
            {
                return _Hint1.Value;
            }
            set
            {
                _Hint1.Value = value;
            }
        }


        public VisibilityFlagsArrayHintObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _Hint1 = new CacheSegment<TTypeResolver, global::Voxels.VisibilityFlags[,,]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Voxels.VisibilityFlags[,,]>(ref targetBytes, startOffset, offset, 0, ref _Hint1);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels.Networking
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class C_ChatMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.C_ChatMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.C_ChatMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.MessageText);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::Voxels.Networking.C_ChatMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new C_ChatMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class C_ChatMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.C_ChatMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _MessageText;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string MessageText
        {
            get
            {
                return _MessageText.Value;
            }
            set
            {
                _MessageText.Value = value;
            }
        }


        public C_ChatMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _MessageText = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _MessageText);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class C_HandshakeMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.C_HandshakeMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.C_HandshakeMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.ClientName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.Password);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.ProtocolVersion);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.Networking.C_HandshakeMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new C_HandshakeMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class C_HandshakeMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.C_HandshakeMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _ClientName;
        CacheSegment<TTypeResolver, string> _Password;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string ClientName
        {
            get
            {
                return _ClientName.Value;
            }
            set
            {
                _ClientName.Value = value;
            }
        }

        // 2
        public override string Password
        {
            get
            {
                return _Password.Value;
            }
            set
            {
                _Password.Value = value;
            }
        }

        // 3
        public override int ProtocolVersion
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public C_HandshakeMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _ClientName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _Password = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _ClientName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _Password);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class C_PongMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.C_PongMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.C_PongMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.Networking.C_PongMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new C_PongMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class C_PongMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.C_PongMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public C_PongMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class BaseMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.BaseMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.BaseMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Voxels.Networking.BaseMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new BaseMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class BaseMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.BaseMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public BaseMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class S_HandshakeMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.S_HandshakeMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.S_HandshakeMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte>(ref bytes, startOffset, offset, 0, value.CommandID);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.ServerName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.MOTD);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.ProtocolVersion);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Voxels.Networking.S_HandshakeMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new S_HandshakeMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class S_HandshakeMessageObjectSegment<TTypeResolver> : global::Voxels.Networking.S_HandshakeMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _ServerName;
        CacheSegment<TTypeResolver, string> _MOTD;

        // 0
        public override byte CommandID
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, byte>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string ServerName
        {
            get
            {
                return _ServerName.Value;
            }
            set
            {
                _ServerName.Value = value;
            }
        }

        // 2
        public override string MOTD
        {
            get
            {
                return _MOTD.Value;
            }
            set
            {
                _MOTD.Value = value;
            }
        }

        // 3
        public override int ProtocolVersion
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public S_HandshakeMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _ServerName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _MOTD = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, byte>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _ServerName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _MOTD);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class BlockDataFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockData>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, global::Voxels.BlockType> formatter0;
        readonly Formatter<TTypeResolver, byte> formatter1;
        readonly Formatter<TTypeResolver, byte> formatter2;
        readonly Formatter<TTypeResolver, byte> formatter3;
        readonly Formatter<TTypeResolver, ushort> formatter4;
        readonly Formatter<TTypeResolver, ushort> formatter5;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                    && formatter3.NoUseDirtyTracker
                    && formatter4.NoUseDirtyTracker
                    && formatter5.NoUseDirtyTracker
                ;
            }
        }

        public BlockDataFormatter()
        {
            formatter0 = Formatter<TTypeResolver, global::Voxels.BlockType>.Default;
            formatter1 = Formatter<TTypeResolver, byte>.Default;
            formatter2 = Formatter<TTypeResolver, byte>.Default;
            formatter3 = Formatter<TTypeResolver, byte>.Default;
            formatter4 = Formatter<TTypeResolver, ushort>.Default;
            formatter5 = Formatter<TTypeResolver, ushort>.Default;
            
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockData value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 8);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.Type);
            offset += formatter1.Serialize(ref bytes, offset, value.Subtype);
            offset += formatter2.Serialize(ref bytes, offset, value.SunLevel);
            offset += formatter3.Serialize(ref bytes, offset, value.LightLevel);
            offset += formatter4.Serialize(ref bytes, offset, value.AddColor);
            offset += formatter5.Serialize(ref bytes, offset, value.Metadata);
            return offset - startOffset;
        }

        public override global::Voxels.BlockData Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = formatter3.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = formatter4.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item5 = formatter5.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Voxels.BlockData(item0, item1, item2, item3, item4, item5);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.UnityEngine
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class Vector3Formatter<TTypeResolver> : Formatter<TTypeResolver, global::UnityEngine.Vector3>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        readonly Formatter<TTypeResolver, float> formatter1;
        readonly Formatter<TTypeResolver, float> formatter2;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                ;
            }
        }

        public Vector3Formatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            formatter1 = Formatter<TTypeResolver, float>.Default;
            formatter2 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::UnityEngine.Vector3 value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 12);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.x);
            offset += formatter1.Serialize(ref bytes, offset, value.y);
            offset += formatter2.Serialize(ref bytes, offset, value.z);
            return offset - startOffset;
        }

        public override global::UnityEngine.Vector3 Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::UnityEngine.Vector3(item0, item1, item2);
        }
    }

    public class Vector2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::UnityEngine.Vector2>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        readonly Formatter<TTypeResolver, float> formatter1;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                ;
            }
        }

        public Vector2Formatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            formatter1 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::UnityEngine.Vector2 value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 8);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.x);
            offset += formatter1.Serialize(ref bytes, offset, value.y);
            return offset - startOffset;
        }

        public override global::UnityEngine.Vector2 Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::UnityEngine.Vector2(item0, item1);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class BlockTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockType value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.BlockType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.BlockType)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableBlockTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.BlockType? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.BlockType)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class BlockTypeEqualityComparer : IEqualityComparer<global::Voxels.BlockType>
    {
        public bool Equals(global::Voxels.BlockType x, global::Voxels.BlockType y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.BlockType x)
        {
            return (int)(Byte)x;
        }
    }



    public class BlockModelTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockModelType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockModelType value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.BlockModelType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.BlockModelType)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableBlockModelTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockModelType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockModelType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.BlockModelType? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.BlockModelType)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class BlockModelTypeEqualityComparer : IEqualityComparer<global::Voxels.BlockModelType>
    {
        public bool Equals(global::Voxels.BlockModelType x, global::Voxels.BlockModelType y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.BlockModelType x)
        {
            return (int)(Byte)x;
        }
    }



    public class BlockHarvestLevelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockHarvestLevel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockHarvestLevel value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.BlockHarvestLevel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.BlockHarvestLevel)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableBlockHarvestLevelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockHarvestLevel?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockHarvestLevel? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.BlockHarvestLevel? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.BlockHarvestLevel)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class BlockHarvestLevelEqualityComparer : IEqualityComparer<global::Voxels.BlockHarvestLevel>
    {
        public bool Equals(global::Voxels.BlockHarvestLevel x, global::Voxels.BlockHarvestLevel y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.BlockHarvestLevel x)
        {
            return (int)(Byte)x;
        }
    }



    public class VisibilityFlagsFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.VisibilityFlags>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.VisibilityFlags value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.VisibilityFlags Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.VisibilityFlags)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableVisibilityFlagsFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.VisibilityFlags?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.VisibilityFlags? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.VisibilityFlags? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.VisibilityFlags)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class VisibilityFlagsEqualityComparer : IEqualityComparer<global::Voxels.VisibilityFlags>
    {
        public bool Equals(global::Voxels.VisibilityFlags x, global::Voxels.VisibilityFlags y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.VisibilityFlags x)
        {
            return (int)(Byte)x;
        }
    }



    public class DirIndexFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.DirIndex>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.DirIndex value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.DirIndex Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.DirIndex)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableDirIndexFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.DirIndex?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.DirIndex? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.DirIndex? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.DirIndex)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class DirIndexEqualityComparer : IEqualityComparer<global::Voxels.DirIndex>
    {
        public bool Equals(global::Voxels.DirIndex x, global::Voxels.DirIndex y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.DirIndex x)
        {
            return (int)(Byte)x;
        }
    }



    public class BlockMeshTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockMeshType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockMeshType value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.BlockMeshType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.BlockMeshType)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableBlockMeshTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.BlockMeshType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.BlockMeshType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.BlockMeshType? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.BlockMeshType)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class BlockMeshTypeEqualityComparer : IEqualityComparer<global::Voxels.BlockMeshType>
    {
        public bool Equals(global::Voxels.BlockMeshType x, global::Voxels.BlockMeshType y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.BlockMeshType x)
        {
            return (int)(Byte)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Voxels.Networking
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class CStateFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.CState>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.CState value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.Networking.CState Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.Networking.CState)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableCStateFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.CState?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.CState? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.Networking.CState? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.Networking.CState)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class CStateEqualityComparer : IEqualityComparer<global::Voxels.Networking.CState>
    {
        public bool Equals(global::Voxels.Networking.CState x, global::Voxels.Networking.CState y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.Networking.CState x)
        {
            return (int)(Byte)x;
        }
    }



    public class ServerPacketIDFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.ServerPacketID>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.ServerPacketID value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.Networking.ServerPacketID Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.Networking.ServerPacketID)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableServerPacketIDFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.ServerPacketID?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.ServerPacketID? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.Networking.ServerPacketID? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.Networking.ServerPacketID)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class ServerPacketIDEqualityComparer : IEqualityComparer<global::Voxels.Networking.ServerPacketID>
    {
        public bool Equals(global::Voxels.Networking.ServerPacketID x, global::Voxels.Networking.ServerPacketID y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.Networking.ServerPacketID x)
        {
            return (int)(Byte)x;
        }
    }



    public class ClientPacketIDFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.ClientPacketID>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.ClientPacketID value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::Voxels.Networking.ClientPacketID Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Voxels.Networking.ClientPacketID)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }


    public class NullableClientPacketIDFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Voxels.Networking.ClientPacketID?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Voxels.Networking.ClientPacketID? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::Voxels.Networking.ClientPacketID? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Voxels.Networking.ClientPacketID)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }



    public class ClientPacketIDEqualityComparer : IEqualityComparer<global::Voxels.Networking.ClientPacketID>
    {
        public bool Equals(global::Voxels.Networking.ClientPacketID x, global::Voxels.Networking.ClientPacketID y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::Voxels.Networking.ClientPacketID x)
        {
            return (int)(Byte)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
