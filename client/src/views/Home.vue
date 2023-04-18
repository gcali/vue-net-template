<template lang="pug">
.home Hello world! Time: {{ currentTime }}

</template>

<script lang="ts">
import Vue from 'vue'

export default Vue.extend({
    data() {
        return {
            currentTime: new Date().toString(),
            mounted: false
        }
    },
    mounted() {
        this.mounted = true;
        const callback = () => {
            this.currentTime = new Date().toString();
            if (this.mounted) {
                setTimeout(callback, 1000)
            }
        };
        callback();
    },
    beforeDestroy() {
        this.mounted = false;
    }
})
</script>

<style lang="scss">
.home {
    border: 1px solid grey;
    padding: 1em 2em;
}
</style>
